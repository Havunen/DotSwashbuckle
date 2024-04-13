using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using DotSwashbuckle.AspNetCore.SwaggerGen;
using System.Collections;

namespace DotSwashbuckle.AspNetCore.Newtonsoft
{
    public class NewtonsoftDataContractResolver : ISerializerDataContractResolver
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IContractResolver _contractResolver;

        public NewtonsoftDataContractResolver(JsonSerializerSettings serializerSettings)
        {
            _serializerSettings = serializerSettings;
            _contractResolver = serializerSettings.ContractResolver ?? new DefaultContractResolver();
        }

        public DataContract GetDataContractForType(Type type)
        {
            if (type.IsOneOf(typeof(object), typeof(JToken), typeof(JObject), typeof(JArray)))
            {
                return DataContract.ForDynamic(
                    underlyingType: type,
                    jsonConverter: JsonConverterFunc);
            }

            var jsonContract = _contractResolver.ResolveContract(type);

            if (jsonContract is JsonPrimitiveContract && !jsonContract.UnderlyingType.IsEnum)
            {
                var primitiveTypeAndFormat = CommonFormats.PrimitiveTypesAndFormats.TryGetValue(jsonContract.UnderlyingType, out var format)
                    ? format
                    : Tuple.Create(DataType.String, (string)null);

                return DataContract.ForPrimitive(
                    underlyingType: jsonContract.UnderlyingType,
                    dataType: primitiveTypeAndFormat.Item1,
                    dataFormat: primitiveTypeAndFormat.Item2,
                    jsonConverter: JsonConverterFunc);
            }

            if (jsonContract is JsonPrimitiveContract && jsonContract.UnderlyingType.IsEnum)
            {
                var enumValues = jsonContract.UnderlyingType.GetEnumValues();

                //Test to determine if the serializer will treat as string
                var serializeAsString = enumValues.Length > 0
                    && JsonConverterFunc(enumValues.GetValue(0)).StartsWith("\"");

                var primitiveTypeAndFormat = serializeAsString
                    ? CommonFormats.PrimitiveTypesAndFormats[typeof(string)]
                    : CommonFormats.PrimitiveTypesAndFormats[jsonContract.UnderlyingType.GetEnumUnderlyingType()];

                return DataContract.ForPrimitive(
                    underlyingType: jsonContract.UnderlyingType,
                    dataType: primitiveTypeAndFormat.Item1,
                    dataFormat: primitiveTypeAndFormat.Item2,
                    jsonConverter: JsonConverterFunc);
            }

            if (jsonContract is JsonArrayContract jsonArrayContract)
            {
                return DataContract.ForArray(
                    underlyingType: jsonArrayContract.UnderlyingType,
                    itemType: jsonArrayContract.CollectionItemType ?? typeof(object),
                    jsonConverter: JsonConverterFunc);
            }

            if (JsonSerializerDataContractResolver.IsSupportedDictionary(type, out Type _, out Type valueType1))
            {
                return DataContract.ForDictionary(
                    underlyingType: type,
                    valueType: valueType1,
                    keys: null, // STJ doesn't currently support dictionaries with enum key types
                    jsonConverter: JsonConverterFunc);
            }

            if (JsonSerializerDataContractResolver.IsSupportedCollection(type, out Type itemType))
            {
                return DataContract.ForArray(
                    underlyingType: type,
                    itemType: itemType,
                    jsonConverter: JsonConverterFunc);
            }

            if (jsonContract is JsonDictionaryContract jsonDictionaryContract)
            {
                var keyType = jsonDictionaryContract.DictionaryKeyType ?? typeof(object);
                var valueType = jsonDictionaryContract.DictionaryValueType ?? typeof(object);

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
                    underlyingType: jsonDictionaryContract.UnderlyingType,
                    valueType: valueType,
                    keys: keys,
                    jsonConverter: JsonConverterFunc);
            }

            if (jsonContract is JsonObjectContract jsonObjectContract)
            {
                string typeNameProperty = null;
                string typeNameValue = null;

                if (_serializerSettings.TypeNameHandling == TypeNameHandling.Objects
                    || _serializerSettings.TypeNameHandling == TypeNameHandling.All
                    || _serializerSettings.TypeNameHandling == TypeNameHandling.Auto)
                {
                    typeNameProperty = "$type";

                    typeNameValue = _serializerSettings.TypeNameAssemblyFormatHandling == TypeNameAssemblyFormatHandling.Full
                        ? jsonObjectContract.UnderlyingType.AssemblyQualifiedName
                        : $"{jsonObjectContract.UnderlyingType.FullName}, {jsonObjectContract.UnderlyingType.Assembly.GetName().Name}";
                }

                return DataContract.ForObject(
                    underlyingType: jsonObjectContract.UnderlyingType,
                    properties: GetDataPropertiesFor(jsonObjectContract, out Type extensionDataType),
                    extensionDataType: extensionDataType,
                    typeNameProperty: typeNameProperty,
                    typeNameValue: typeNameValue,
                    jsonConverter: JsonConverterFunc);
            }

            return DataContract.ForDynamic(
                underlyingType: type,
                jsonConverter: JsonConverterFunc);
        }

        private string JsonConverterFunc(object value)
        {
            return JsonConvert.SerializeObject(value, _serializerSettings);
        }

        private IEnumerable<DataProperty> GetDataPropertiesFor(JsonObjectContract jsonObjectContract, out Type extensionDataType)
        {
            var dataProperties = new List<DataProperty>();

            foreach (var jsonProperty in jsonObjectContract.Properties)
            {
                if (jsonProperty.Ignored) continue;

                var required = jsonProperty.Required != Required.Default
                    ? jsonProperty.Required
                    : jsonObjectContract.ItemRequired ?? Required.Default;

                var isSetViaConstructor = jsonProperty.DeclaringType != null && jsonProperty.DeclaringType.GetConstructors()
                    .SelectMany(c => c.GetParameters())
                    .Any(p =>
                    {
                        // Newtonsoft supports setting via constructor if either underlying OR JSON names match
                        return
                            string.Equals(p.Name, jsonProperty.UnderlyingName, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(p.Name, jsonProperty.PropertyName, StringComparison.OrdinalIgnoreCase);
                    });

                jsonProperty.TryGetMemberInfo(out MemberInfo memberInfo);

                dataProperties.Add(
                    new DataProperty(
                        name: jsonProperty.PropertyName,
                        isRequired: required == Required.Always || required == Required.AllowNull,
                        isNullable: (required == Required.AllowNull || required == Required.Default) && jsonProperty.PropertyType.IsReferenceOrNullableType(),
                        isReadOnly: jsonProperty.Readable && !jsonProperty.Writable && !isSetViaConstructor,
                        isWriteOnly: jsonProperty.Writable && !jsonProperty.Readable,
                        memberType: jsonProperty.PropertyType,
                        memberInfo: memberInfo));
            }

            extensionDataType = jsonObjectContract.ExtensionDataValueType;

            // If applicable, honor ProblemDetailsConverter
            if (jsonObjectContract.UnderlyingType.IsAssignableTo(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails))
                && _serializerSettings.Converters.OfType<Microsoft.AspNetCore.Mvc.NewtonsoftJson.ProblemDetailsConverter>().Any())
            {
                var extensionsProperty = dataProperties.FirstOrDefault(p => p.MemberInfo.Name == "Extensions");
                if (extensionsProperty != null)
                {
                    dataProperties.Remove(extensionsProperty);
                    extensionDataType = typeof(object);
                }
            }

            return dataProperties;
        }
    }
}
