using DotSwashbuckle.AspNetCore.SwaggerGen.Utils;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments
{
    internal static class ExampleParser
    {
        internal static IOpenApiAny ParseNodeExample(
            string example,
            OpenApiSchema schema,
            SchemaRepository schemaRepository
        )
        {
            var resolvedType = schema?.ResolveType(schemaRepository);
            var shouldBeQuoted = (
                string.Equals(resolvedType, "string", StringComparison.Ordinal) ||
                string.Equals(resolvedType, "array", StringComparison.Ordinal)
            ) && !string.Equals(example, "null", StringComparison.Ordinal);
            var exampleValue = WhiteSpaceCleaner.Condense(example);

            return OpenApiAnyFactory.CreateFromJson(shouldBeQuoted ? $"\"{exampleValue}\"" : exampleValue);
        }
    }
}
