﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class SchemaGenerator : ISchemaGenerator
    {
        private readonly SchemaGeneratorOptions _generatorOptions;
        private readonly ISerializerDataContractResolver _serializerDataContractResolver;

        public SchemaGenerator(SchemaGeneratorOptions generatorOptions, ISerializerDataContractResolver serializerDataContractResolver)
        {
            _generatorOptions = generatorOptions;
            _serializerDataContractResolver = serializerDataContractResolver;
        }

        public OpenApiSchema GenerateSchema(
            Type modelType,
            SchemaRepository schemaRepository,
            MemberInfo memberInfo = null,
            ParameterInfo parameterInfo = null,
            ApiParameterRouteInfo routeInfo = null,
            bool isEffectiveTypeNeeded = true)
        {
            if (memberInfo != null)
                return GenerateSchemaForMember(modelType, schemaRepository, memberInfo);

            if (parameterInfo != null)
                return GenerateSchemaForParameter(modelType, schemaRepository, parameterInfo, routeInfo);

            return GenerateSchemaForType(modelType, schemaRepository, isEffectiveTypeNeeded);
        }

        private OpenApiSchema GenerateSchemaForMember(
            Type modelType,
            SchemaRepository schemaRepository,
            MemberInfo memberInfo,
            DataProperty dataProperty = null)
        {
            var (dataContract, isNullable) = GetDataContractFor(modelType);

            var schema = _generatorOptions.UseOneOfForPolymorphism && IsBaseTypeWithKnownTypesDefined(dataContract, out var knownTypesDataContracts)
                ? GeneratePolymorphicSchema(schemaRepository, knownTypesDataContracts)
                : GenerateConcreteSchema(dataContract, schemaRepository, isNullable);

            if (_generatorOptions.UseAllOfToExtendReferenceSchemas && schema.Reference != null)
            {
                schema.AllOf = new[] { new OpenApiSchema { Reference = schema.Reference } };
                schema.Reference = null;
            }

            if (schema.Reference == null)
            {
                var customAttributes = memberInfo.GetInlineAndMetadataAttributes();

                // Nullable, ReadOnly & WriteOnly are only relevant for Schema "properties" (i.e. where dataProperty is non-null)
                if (dataProperty != null)
                {
                    var requiredAttribute = customAttributes.OfType<RequiredAttribute>().FirstOrDefault();
                    var hasRequiredMemberAttribute = customAttributes.OfType<RequiredMemberAttribute>().Any();

                    if (_generatorOptions.SupportNonNullableReferenceTypes)
                    {
                        schema.Nullable = dataProperty.IsNullable && requiredAttribute == null &&
                                          !hasRequiredMemberAttribute && !memberInfo.IsNonNullableReferenceType();
                        if (!schema.Nullable)
                        {
                            dataProperty.IsNullable = false;
                            dataProperty.IsRequired = true;
                        }
                    }
                    else
                    {
                        schema.Nullable = dataProperty.IsNullable && requiredAttribute == null &&
                                          !hasRequiredMemberAttribute;
                    }

                    schema.ReadOnly = dataProperty.IsReadOnly;
                    schema.WriteOnly = dataProperty.IsWriteOnly;
                    schema.MinLength = modelType == typeof(string) && (hasRequiredMemberAttribute || requiredAttribute is { AllowEmptyStrings: false }) ? 1 : null;
                }

                var defaultValueAttribute = customAttributes.OfType<DefaultValueAttribute>().FirstOrDefault();
                if (defaultValueAttribute != null)
                {
                    var defaultAsJson = dataContract.JsonConverter(defaultValueAttribute.Value);
                    schema.Default = OpenApiAnyFactory.CreateFromJson(defaultAsJson);
                }

                var obsoleteAttribute = customAttributes.OfType<ObsoleteAttribute>().FirstOrDefault();
                if (obsoleteAttribute != null)
                {
                    schema.Deprecated = true;
                }

                // NullableAttribute behaves diffrently for Dictionaries
                if (schema.AdditionalPropertiesAllowed && modelType.IsGenericType && modelType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    schema.AdditionalProperties.Nullable = !memberInfo.IsDictionaryValueNonNullable();
                }

                schema.ApplyValidationAttributes(customAttributes);

                ApplyFilters(schema, modelType, schemaRepository, memberInfo: memberInfo);
            }

            return schema;
        }

        private OpenApiSchema GenerateSchemaForParameter(
            Type modelType,
            SchemaRepository schemaRepository,
            ParameterInfo parameterInfo,
            ApiParameterRouteInfo routeInfo)
        {
            var (dataContract, isNullable) = GetDataContractFor(modelType);

            var schema = _generatorOptions.UseOneOfForPolymorphism && IsBaseTypeWithKnownTypesDefined(dataContract, out var knownTypesDataContracts)
                ? GeneratePolymorphicSchema(schemaRepository, knownTypesDataContracts)
                : GenerateConcreteSchema(dataContract, schemaRepository, isNullable);

            if (_generatorOptions.UseAllOfToExtendReferenceSchemas && schema.Reference != null)
            {
                schema.AllOf = new[] { new OpenApiSchema { Reference = schema.Reference } };
                schema.Reference = null;
            }

            if (schema.Reference == null)
            {
                var customAttributes = parameterInfo.GetCustomAttributes();

                var defaultValue = parameterInfo.HasDefaultValue
                    ? parameterInfo.DefaultValue
                    : customAttributes.OfType<DefaultValueAttribute>().FirstOrDefault()?.Value;

                if (defaultValue != null)
                {
                    var defaultAsJson = dataContract.JsonConverter(defaultValue);
                    schema.Default = OpenApiAnyFactory.CreateFromJson(defaultAsJson);
                }

                schema.ApplyValidationAttributes(customAttributes);
                if (routeInfo != null)
                {
                    schema.ApplyRouteConstraints(routeInfo);
                }

                ApplyFilters(schema, modelType, schemaRepository, parameterInfo: parameterInfo);
            }

            return schema;
        }

        private OpenApiSchema GenerateSchemaForType(Type modelType, SchemaRepository schemaRepository, bool isEffectiveTypeNeeded = true)
        {
            var (dataContract, isNullable) = GetDataContractFor(modelType, isEffectiveTypeNeeded);

            var schema = _generatorOptions.UseOneOfForPolymorphism && IsBaseTypeWithKnownTypesDefined(dataContract, out var knownTypesDataContracts)
                ? GeneratePolymorphicSchema(schemaRepository, knownTypesDataContracts)
                : GenerateConcreteSchema(dataContract, schemaRepository, isNullable);

            if (schema.Reference == null)
            {
                ApplyFilters(schema, modelType, schemaRepository);
            }

            return schema;
        }

        private (DataContract dataContract, bool isNullable) GetDataContractFor(Type modelType, bool isEffectiveTypeNeeded = true)
        {
            Type effectiveType = null;
            var isNullable = false;

            if (isEffectiveTypeNeeded)
            {
                effectiveType = Nullable.GetUnderlyingType(modelType);
                isNullable = effectiveType != null;
                effectiveType ??= modelType;
            }

            effectiveType ??= modelType;


            return (
                _serializerDataContractResolver.GetDataContractForType(effectiveType),
                isNullable
            );
        }

        private bool IsBaseTypeWithKnownTypesDefined(DataContract dataContract, out IEnumerable<(DataContract dataContract, bool isNullable)> knownTypesDataContracts)
        {
            knownTypesDataContracts = null;

            if (dataContract.DataType != DataType.Object) return false;

            var subTypes = _generatorOptions
                .SubTypesSelector(dataContract.UnderlyingType)
                .Where(type => !type.IsGenericTypeDefinition);

            if (!subTypes.Any()) return false;

            var knownTypes = !dataContract.UnderlyingType.IsAbstract
                ? new[] { dataContract.UnderlyingType }.Union(subTypes)
                : subTypes;

            knownTypesDataContracts = knownTypes.Select(knownType => GetDataContractFor(knownType));
            return true;
        }

        private OpenApiSchema GeneratePolymorphicSchema(
            SchemaRepository schemaRepository,
            IEnumerable<(DataContract, bool)> knownTypesDataContracts)
        {
            return new OpenApiSchema
            {
                OneOf = knownTypesDataContracts
                    .Select(dataContractNullableTuple => GenerateConcreteSchema(
                        dataContractNullableTuple.Item1,
                        schemaRepository,
                        dataContractNullableTuple.Item2
                    ))
                    .ToList()
            };
        }

        private static readonly Type[] BinaryStringTypes = new[]
        {
            typeof(IFormFile),
            typeof(FileResult),
            typeof(System.IO.Stream),
            typeof(System.IO.Pipelines.PipeReader),
        };

        private OpenApiSchema GenerateConcreteSchema(
            DataContract dataContract,
            SchemaRepository schemaRepository,
            bool isNullable
        )
        {
            if (TryGetCustomTypeMapping(dataContract.UnderlyingType, out Func<OpenApiSchema> customSchemaFactory))
            {
                return customSchemaFactory();
            }

            if (dataContract.UnderlyingType.IsAssignableToOneOf(BinaryStringTypes))
            {
                return new OpenApiSchema { Type = "string", Format = "binary" };
            }

            Func<OpenApiSchema> schemaFactory;
            bool returnAsReference;

            switch (dataContract.DataType)
            {
                case DataType.Boolean:
                case DataType.Integer:
                case DataType.Number:
                case DataType.String:
                    {
                        schemaFactory = () => CreatePrimitiveSchema(dataContract, isNullable);
                        returnAsReference = dataContract.UnderlyingType.IsEnum && !_generatorOptions.UseInlineDefinitionsForEnums;
                        break;
                    }

                case DataType.Array:
                    {
                        schemaFactory = () => CreateArraySchema(dataContract, schemaRepository);
                        returnAsReference = dataContract.UnderlyingType == dataContract.ArrayItemType;
                        break;
                    }

                case DataType.Dictionary:
                    {
                        schemaFactory = () => CreateDictionarySchema(dataContract, schemaRepository);
                        returnAsReference = dataContract.UnderlyingType == dataContract.DictionaryValueType;
                        break;
                    }

                case DataType.Object:
                    {
                        schemaFactory = () => CreateObjectSchema(dataContract, schemaRepository);
                        returnAsReference = true;
                        break;
                    }

                default:
                    {
                        schemaFactory = () => new OpenApiSchema();
                        returnAsReference = false;
                        break;
                    }
            }

            return returnAsReference
                ? GenerateReferencedSchema(dataContract, schemaRepository, schemaFactory)
                : schemaFactory();
        }

        private bool TryGetCustomTypeMapping(Type modelType, out Func<OpenApiSchema> schemaFactory)
        {
            return _generatorOptions.CustomTypeMappings.TryGetValue(modelType, out schemaFactory)
                || (modelType.IsConstructedGenericType && _generatorOptions.CustomTypeMappings.TryGetValue(modelType.GetGenericTypeDefinition(), out schemaFactory));
        }

        private OpenApiSchema CreatePrimitiveSchema(DataContract dataContract, bool isNullable)
        {
            var underlyingType = dataContract.UnderlyingType;
            var schema = new OpenApiSchema
            {
                Type = dataContract.DataType.ToString().ToLower(CultureInfo.InvariantCulture),
                Format = dataContract.DataFormat,
                Nullable = isNullable || Nullable.GetUnderlyingType(underlyingType) != null
            };

            if (underlyingType.IsEnum)
            {
                schema.Enum = underlyingType.GetEnumValues()
                    .Cast<object>()
                    .Select(value => dataContract.JsonConverter(value))
                    .Distinct()
                    .Select(valueAsJson => OpenApiAnyFactory.CreateFromJson(valueAsJson))
                    .ToList();
            }

            if (dataContract.DataType == DataType.Integer)
            {
                if (underlyingType == typeof(ushort))
                {
                    schema.Minimum = 0;
                    schema.Maximum = ushort.MaxValue;
                } else if (underlyingType == typeof(uint))
                {
                    schema.Minimum = 0;
                    schema.Maximum = uint.MaxValue;
                } else if (underlyingType == typeof(ulong))
                {
                    schema.Minimum = 0;
                    schema.Maximum = ulong.MaxValue;
                } else if (underlyingType == typeof(UInt128))
                {
                    schema.Minimum = 0;
                    // OpenApiMaximum property is too small to represent UInt128.MaxValue
                    //schema.Maximum = UInt128.MaxValue;
                }

            }

            return schema;
        }

        private OpenApiSchema CreateArraySchema(DataContract dataContract, SchemaRepository schemaRepository)
        {
            var hasUniqueItems = dataContract.UnderlyingType.IsConstructedFrom(typeof(ISet<>), out _)
                || dataContract.UnderlyingType.IsConstructedFrom(typeof(KeyedCollection<,>), out _)
                || dataContract.UnderlyingType.IsConstructedFrom(typeof(IReadOnlySet<>), out _);

            return new OpenApiSchema
            {
                Type = "array",
                Items = GenerateSchema(dataContract.ArrayItemType, schemaRepository, isEffectiveTypeNeeded: false),
                UniqueItems = hasUniqueItems ? (bool?)true : null
            };
        }

        private OpenApiSchema CreateDictionarySchema(DataContract dataContract, SchemaRepository schemaRepository)
        {
            if (dataContract.DictionaryKeys != null)
            {
                // This is a special case where the set of key values is known (e.g. if the key type is an enum)
                return new OpenApiSchema
                {
                    Type = "object",
                    Properties = dataContract.DictionaryKeys.ToDictionary(
                        name => name,
                        name => GenerateSchema(dataContract.DictionaryValueType, schemaRepository)),
                    AdditionalPropertiesAllowed = false,
                };
            }
            else
            {
                return new OpenApiSchema
                {
                    Type = "object",
                    AdditionalPropertiesAllowed = true,
                    AdditionalProperties = GenerateSchema(dataContract.DictionaryValueType, schemaRepository)
                };
            }
        }

        private OpenApiSchema CreateObjectSchema(DataContract dataContract, SchemaRepository schemaRepository)
        {
            var schema = new OpenApiSchema
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal),
                Required = new SortedSet<string>(),
                AdditionalPropertiesAllowed = false
            };

            var applicableDataProperties = dataContract.ObjectProperties;

            if (_generatorOptions.UseAllOfForInheritance || _generatorOptions.UseOneOfForPolymorphism)
            {
                if (IsKnownSubType(dataContract, out var baseTypeDataContractTuple))
                {
                    var baseTypeSchema = GenerateConcreteSchema(
                        baseTypeDataContractTuple.Item1,
                        schemaRepository,
                        baseTypeDataContractTuple.Item2
                    );

                    schema.AllOf.Add(baseTypeSchema);

                    applicableDataProperties = applicableDataProperties
                        .Where(dataProperty => dataProperty.MemberInfo.DeclaringType == dataContract.UnderlyingType);
                }

                if (IsBaseTypeWithKnownTypesDefined(dataContract, out var knownTypesDataContracts))
                {
                    foreach (var knownTypeDataContract in knownTypesDataContracts)
                    {
                        // Ensure schema is generated for all known types
                        GenerateConcreteSchema(knownTypeDataContract.dataContract, schemaRepository, knownTypeDataContract.isNullable);
                    }

                    if (TryGetDiscriminatorFor(dataContract, schemaRepository, knownTypesDataContracts, out var discriminator))
                    {
                        schema.Properties.Add(discriminator.PropertyName, new OpenApiSchema { Type = "string" });
                        schema.Required.Add(discriminator.PropertyName);
                        schema.Discriminator = discriminator;
                    }
                }
            }

            foreach (var dataProperty in applicableDataProperties)
            {
                var customAttributes = dataProperty.MemberInfo?.GetInlineAndMetadataAttributes() ?? [];

                if (_generatorOptions.IgnoreObsoleteProperties && customAttributes.OfType<ObsoleteAttribute>().Any())
                    continue;

                schema.Properties[dataProperty.Name] = dataProperty.MemberInfo != null
                    ? GenerateSchemaForMember(dataProperty.MemberType, schemaRepository, dataProperty.MemberInfo, dataProperty)
                    : GenerateSchemaForType(dataProperty.MemberType, schemaRepository);

                if (
                    dataProperty.IsRequired ||
                    customAttributes.OfType<RequiredAttribute>().Any() ||
                    customAttributes.OfType<RequiredMemberAttribute>().Any()
                )
                {
                    schema.Required.Add(dataProperty.Name);
                }
            }

            if (dataContract.ObjectExtensionDataType != null)
            {
                schema.AdditionalPropertiesAllowed = true;
                schema.AdditionalProperties = GenerateSchema(dataContract.ObjectExtensionDataType, schemaRepository);
            }

            return schema;
        }

        private bool IsKnownSubType(DataContract dataContract, out (DataContract, bool) baseTypeDataContract)
        {
            baseTypeDataContract = (null, false);

            var baseType = dataContract.UnderlyingType.BaseType;

            if (baseType == null ||
                baseType == typeof(object) ||
                !_generatorOptions.SubTypesSelector(baseType).Any(type =>
                    type == dataContract.UnderlyingType ||
                    (type.IsGenericTypeDefinition && dataContract.UnderlyingType.IsConstructedGenericType && type == dataContract.UnderlyingType.GetGenericTypeDefinition())
                ))
            {

                return false;
            }

            baseTypeDataContract = GetDataContractFor(baseType);
            return true;
        }

        private bool TryGetDiscriminatorFor(
            DataContract dataContract,
            SchemaRepository schemaRepository,
            IEnumerable<(DataContract dataContract, bool isNullable)> knownTypesDataContracts,
            out OpenApiDiscriminator discriminator)
        {
            discriminator = null;

            var discriminatorName = _generatorOptions.DiscriminatorNameSelector(dataContract.UnderlyingType)
                ?? dataContract.ObjectTypeNameProperty;

            if (discriminatorName == null) return false;

            discriminator = new OpenApiDiscriminator
            {
                PropertyName = discriminatorName
            };

            foreach (var knownTypeDataContract in knownTypesDataContracts)
            {
                var discriminatorValue = _generatorOptions.DiscriminatorValueSelector(knownTypeDataContract.dataContract.UnderlyingType)
                    ?? knownTypeDataContract.dataContract.ObjectTypeNameValue;

                if (discriminatorValue == null) continue;

                discriminator.Mapping.Add(discriminatorValue, GenerateConcreteSchema(
                    knownTypeDataContract.dataContract,
                    schemaRepository,
                    knownTypeDataContract.isNullable
                ).Reference.ReferenceV3);
            }

            return true;
        }

        private OpenApiSchema GenerateReferencedSchema(
            DataContract dataContract,
            SchemaRepository schemaRepository,
            Func<OpenApiSchema> definitionFactory)
        {
            if (schemaRepository.TryLookupByType(dataContract.UnderlyingType, out OpenApiSchema referenceSchema))
                return referenceSchema;

            var schemaId = _generatorOptions.SchemaIdSelector(dataContract.UnderlyingType);

            schemaRepository.RegisterType(dataContract.UnderlyingType, schemaId);

            var schema = definitionFactory();
            ApplyFilters(schema, dataContract.UnderlyingType, schemaRepository);

            return schemaRepository.AddDefinition(schemaId, schema);
        }

        private void ApplyFilters(
            OpenApiSchema schema,
            Type type,
            SchemaRepository schemaRepository,
            MemberInfo memberInfo = null,
            ParameterInfo parameterInfo = null)
        {
            var filterContext = new SchemaFilterContext(
                type: type,
                schemaGenerator: this,
                schemaRepository: schemaRepository,
                memberInfo: memberInfo,
                parameterInfo: parameterInfo);

            foreach (var filter in _generatorOptions.SchemaFilters)
            {
                filter.Apply(schema, filterContext);
            }
        }
    }
}