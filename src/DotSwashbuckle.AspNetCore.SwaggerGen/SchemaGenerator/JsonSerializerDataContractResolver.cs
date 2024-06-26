﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class JsonSerializerDataContractResolver : ISerializerDataContractResolver
    {
        private readonly JsonSerializerOptions _serializerOptions;

        public JsonSerializerDataContractResolver(JsonSerializerOptions serializerOptions)
        {
            _serializerOptions = serializerOptions;
        }

        public DataContract GetDataContractForType(Type type)
        {
            if (type.IsOneOf(typeof(object), typeof(JsonDocument), typeof(JsonElement)))
            {
                return DataContract.ForDynamic(
                    underlyingType: type,
                    jsonConverter: JsonConverterFunc);
            }

            if (CommonFormats.PrimitiveTypesAndFormats.TryGetValue(type, out var primitiveTypeAndFormat1))
            {
                return DataContract.ForPrimitive(
                    underlyingType: type,
                    dataType: primitiveTypeAndFormat1.Item1,
                    dataFormat: primitiveTypeAndFormat1.Item2,
                    jsonConverter: JsonConverterFunc);
            }

            if (type.IsEnum)
            {
                var enumValues = type.GetEnumValues();

                //Test to determine if the serializer will treat as string
                var serializeAsString = enumValues.Length > 0
                    && JsonConverterFunc(enumValues.GetValue(0)).StartsWith("\"");

                var primitiveTypeAndFormat = serializeAsString
                    ? CommonFormats.PrimitiveTypesAndFormats[typeof(string)]
                    : CommonFormats.PrimitiveTypesAndFormats[type.GetEnumUnderlyingType()];

                return DataContract.ForPrimitive(
                    underlyingType: type,
                    dataType: primitiveTypeAndFormat.Item1,
                    dataFormat: primitiveTypeAndFormat.Item2,
                    jsonConverter: JsonConverterFunc);
            }

            if (IsSupportedDictionary(type, out Type keyType, out Type valueType))
            {
                IEnumerable<string> keys = null;

                if (keyType.IsEnum)
                {
                    // This is a special case where we know the possible key values
                    var enumValuesAsJson = keyType.GetEnumValues()
                        .Cast<object>()
                        .Select(value => JsonConverterFunc(value));

                    keys = enumValuesAsJson.Any(json => json.StartsWith("\""))
                        ? enumValuesAsJson.Select(json => json.Replace("\"", string.Empty))
                        : keyType.GetEnumNames();
                }

                return DataContract.ForDictionary(
                    underlyingType: type,
                    valueType: valueType,
                    keys: keys,
                    jsonConverter: JsonConverterFunc);
            }

            if (IsSupportedCollection(type, out Type itemType))
            {
                return DataContract.ForArray(
                    underlyingType: type,
                    itemType: itemType,
                    jsonConverter: JsonConverterFunc);
            }

            return DataContract.ForObject(
                underlyingType: type,
                properties: GetDataPropertiesFor(type, out Type extensionDataType),
                extensionDataType: extensionDataType,
                jsonConverter: JsonConverterFunc);
        }

        private string JsonConverterFunc(object value)
        {
            return JsonSerializer.Serialize(value, _serializerOptions);
        }

        public static bool IsSupportedDictionary(Type type, out Type keyType, out Type valueType)
        {
            if (type.IsConstructedFrom(typeof(IDictionary<,>), out Type constructedType)
                || type.IsConstructedFrom(typeof(IReadOnlyDictionary<,>), out constructedType))
            {
                keyType = constructedType.GenericTypeArguments[0];
                valueType = constructedType.GenericTypeArguments[1];
                return true;
            }

            if (typeof(IDictionary).IsAssignableFrom(type))
            {
                keyType = valueType = typeof(object);
                return true;
            }

            keyType = valueType = null;
            return false;
        }

        public static bool IsSupportedCollection(Type type, out Type itemType)
        {
            if (type.IsConstructedFrom(typeof(IEnumerable<>), out Type constructedType))
            {
                itemType = constructedType.GenericTypeArguments[0];
                return true;
            }

            if (type.IsConstructedFrom(typeof(IAsyncEnumerable<>), out constructedType))
            {
                itemType = constructedType.GenericTypeArguments[0];
                return true;
            }

            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                itemType = typeof(object);
                return true;
            }

            itemType = null;
            return false;
        }

        private static readonly BindingFlags InstanceBindingAttr = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

        private IEnumerable<DataProperty> GetDataPropertiesFor(Type objectType, out Type extensionDataType)
        {
            extensionDataType = null;

            var publicProperties = objectType.IsInterface
                ? new[] { objectType }.Concat(objectType.GetInterfaces()).SelectMany(i => i.GetProperties(InstanceBindingAttr))
                : objectType.GetProperties(InstanceBindingAttr);

            var applicableProperties = publicProperties
                .Where(property =>
                {
                    bool isIgnoredViaAttribute = true;

                    JsonIgnoreAttribute jsonIgnoreAttribute = property.GetCustomAttribute<JsonIgnoreAttribute>();
                    if (jsonIgnoreAttribute != null)
                    {
                        isIgnoredViaAttribute = jsonIgnoreAttribute.Condition switch
                        {
                            JsonIgnoreCondition.Never => false,
                            JsonIgnoreCondition.Always => true,
                            JsonIgnoreCondition.WhenWritingDefault => false,
                            JsonIgnoreCondition.WhenWritingNull => false,
                            _ => true
                        };
                    }

                    return
                        (property.IsPubliclyReadable() || property.IsPubliclyWritable()) &&
                        !property.GetIndexParameters().Any() &&
                        !(property.HasAttribute<JsonIgnoreAttribute>() && isIgnoredViaAttribute) &&
                        !(_serializerOptions.IgnoreReadOnlyProperties && !property.IsPubliclyWritable());
                })
                .OrderBy(property => property.DeclaringType.GetInheritanceChain().Length);

            var dataProperties = new List<DataProperty>();

            foreach (var propertyInfo in applicableProperties)
            {
                if (propertyInfo.HasAttribute<JsonExtensionDataAttribute>()
                    && propertyInfo.PropertyType.IsConstructedFrom(typeof(IDictionary<,>), out Type constructedDictionary))
                {
                    extensionDataType = constructedDictionary.GenericTypeArguments[1];
                    continue;
                }

                var name = propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name
                    ?? _serializerOptions.PropertyNamingPolicy?.ConvertName(propertyInfo.Name) ?? propertyInfo.Name;

                // .NET 5 introduces support for serializing immutable types via parameterized constructors
                // See https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-immutability?pivots=dotnet-6-0
                var isDeserializedViaConstructor = false;

                var deserializationConstructor = propertyInfo.DeclaringType?.GetConstructors()
                    .OrderBy(c =>
                    {
                        if (c.GetCustomAttribute<JsonConstructorAttribute>() != null) return 1;
                        if (c.GetParameters().Length == 0) return 2;
                        return 3;
                    })
                    .FirstOrDefault();

                isDeserializedViaConstructor = deserializationConstructor != null && deserializationConstructor.GetParameters()
                    .Any(p =>
                    {
                        return
                            string.Equals(p.Name, propertyInfo.Name, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase);
                    });

                dataProperties.Add(
                    new DataProperty(
                        name: name,
                        isRequired: propertyInfo.GetCustomAttribute<JsonRequiredAttribute>() != null,
                        isNullable: propertyInfo.PropertyType.IsReferenceOrNullableType(),
                        isReadOnly: propertyInfo.IsPubliclyReadable() && !propertyInfo.IsPubliclyWritable() && !isDeserializedViaConstructor,
                        isWriteOnly: propertyInfo.IsPubliclyWritable() && !propertyInfo.IsPubliclyReadable(),
                        memberType: propertyInfo.PropertyType,
                        memberInfo: propertyInfo));
            }

            return dataProperties;
        }
    }
}
