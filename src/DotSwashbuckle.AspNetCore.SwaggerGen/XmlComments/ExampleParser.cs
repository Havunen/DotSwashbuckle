using DotSwashbuckle.AspNetCore.SwaggerGen.Utils;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments
{
    public static class ExampleParser
    {
        public static IOpenApiAny ParseNodeExample(
            string example,
            OpenApiSchema schema,
            SchemaRepository schemaRepository
        )
        {
            var resolvedType = schema?.ResolveType(schemaRepository);
            var isStringSchema = (
                string.Equals(resolvedType, "string", StringComparison.Ordinal) ||
                string.Equals(resolvedType, "array", StringComparison.Ordinal)
            ) && !string.Equals(example, "null", StringComparison.Ordinal);
            var exampleValue = WhiteSpaceCleaner.Condense(example);


            var serializedSchema = OpenApiAnyFactory.CreateFromJson(exampleValue);

            if (serializedSchema != null)
            {
                return serializedSchema;
            }

            if (isStringSchema)
            {
                return new OpenApiString(exampleValue);
            }

            return null;
        }
    }
}
