using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class SchemaRepository
    {
        private readonly Dictionary<Type, string> _reservedIds = new Dictionary<Type, string>();

        public SchemaRepository(string documentName = null)
        {
            DocumentName = documentName;
        }

        public string DocumentName { get; }

        public Dictionary<string, OpenApiSchema> Schemas { get; private set; } = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal);

        public void RegisterType(Type type, string schemaId)
        {
            _reservedIds.Add(type, schemaId);
        }

        public bool TryLookupByType(Type type, out OpenApiSchema referenceSchema)
        {
            if (_reservedIds.TryGetValue(type, out string schemaId))
            {
                referenceSchema = new OpenApiSchema
                {
                    Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = schemaId }
                };
                return true;
            }

            referenceSchema = null;
            return false;
        }

        public OpenApiSchema AddDefinition(string schemaId, OpenApiSchema schema)
        {
            if (Schemas.TryGetValue(schemaId, out var existingSchema))
            {
                if (!IsSchemaEqual(schema, existingSchema))
                {
                    throw new InvalidOperationException(
                        $"Can't use schemaId \"${schemaId}\" for schema \"${schema}\". " +
                        $"The same schemaId is already used for type \"${existingSchema}\"");
                }
            }
            else
            {
                Schemas.Add(schemaId, schema);
            }
            

            return new OpenApiSchema
            {
                Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = schemaId }
            };
        }

        // TODO: This method could be optimized by comparing schemas without serializing them to JSON
        // But it should not be a big deal since it's only called when there's a conflict
        private static bool IsSchemaEqual(OpenApiSchema a, OpenApiSchema b)
        {
            var aJson = SerializeSchemaAsString(a);
            var bJson = SerializeSchemaAsString(b);

            return string.Equals(aJson, bJson, StringComparison.Ordinal);
        }

        private static string SerializeSchemaAsString(OpenApiSchema a)
        {
            using var textWriter = new StringWriter(CultureInfo.InvariantCulture);
            var jsonWriter = new OpenApiJsonWriter(textWriter);
            a.SerializeAsV3(jsonWriter);
            return textWriter.ToString();
        }
    }
}
