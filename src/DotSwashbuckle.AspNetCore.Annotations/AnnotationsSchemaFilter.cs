using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.SwaggerGen;
using DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments;

namespace DotSwashbuckle.AspNetCore.Annotations
{
    public class AnnotationsSchemaFilter : ISchemaFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public AnnotationsSchemaFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            ApplyTypeAnnotations(schema, context);

            // NOTE: It's possible for both MemberInfo and ParameterInfo to have non-null values - i.e. when the schema is for a property
            // within a class that is bound to a parameter. In this case, the MemberInfo should take precendence.

            if (context.MemberInfo != null)
            {
                ApplyMemberAnnotations(schema, context.MemberInfo, context);
            }
            else if (context.ParameterInfo != null)
            {
                ApplyParamAnnotations(schema, context.ParameterInfo, context);
            }
        }

        private void ApplyTypeAnnotations(OpenApiSchema schema, SchemaFilterContext context)
        {
            var schemaAttribute = context.Type.GetCustomAttributes<SwaggerSchemaAttribute>()
                .FirstOrDefault();

            if (schemaAttribute != null)
                ApplySchemaAttribute(schema, schemaAttribute, context);

            var schemaFilterAttribute = context.Type.GetCustomAttributes<SwaggerSchemaFilterAttribute>()
                .FirstOrDefault();

            if (schemaFilterAttribute != null)
            {
                var filter = (ISchemaFilter)ActivatorUtilities.CreateInstance(
                    _serviceProvider,
                    schemaFilterAttribute.Type,
                    schemaFilterAttribute.Arguments);

                filter.Apply(schema, context);
            }
        }

        private void ApplyParamAnnotations(
            OpenApiSchema schema,
            ParameterInfo parameterInfo,
            SchemaFilterContext context
        )
        {
            var schemaAttribute = parameterInfo.GetCustomAttributes<SwaggerSchemaAttribute>()
                .FirstOrDefault();

            if (schemaAttribute != null)
                ApplySchemaAttribute(schema, schemaAttribute, context);
        }

        private void ApplyMemberAnnotations(
            OpenApiSchema schema,
            MemberInfo memberInfo,
            SchemaFilterContext context
        )
        {
            var schemaAttribute = memberInfo.GetCustomAttributes<SwaggerSchemaAttribute>()
                .FirstOrDefault();

            if (schemaAttribute != null)
                ApplySchemaAttribute(schema, schemaAttribute, context);
        }

        private void ApplySchemaAttribute(
            OpenApiSchema schema,
            SwaggerSchemaAttribute schemaAttribute,
            SchemaFilterContext context
        )
        {
            if (schemaAttribute.Description != null)
                schema.Description = schemaAttribute.Description;

            if (schemaAttribute.Format != null)
                schema.Format = schemaAttribute.Format;

            if (schemaAttribute.ReadOnlyFlag.HasValue)
                schema.ReadOnly = schemaAttribute.ReadOnlyFlag.Value;

            if (schemaAttribute.WriteOnlyFlag.HasValue)
                schema.WriteOnly = schemaAttribute.WriteOnlyFlag.Value;

            if (schemaAttribute.NullableFlag.HasValue)
                schema.Nullable = schemaAttribute.NullableFlag.Value;

            if (schemaAttribute.Required != null)
                schema.Required = new SortedSet<string>(schemaAttribute.Required);

            if (schemaAttribute.Title != null)
                schema.Title = schemaAttribute.Title;

            if (schemaAttribute.Example != null)
            {
                schema.Example = ExampleParser.ParseNodeExample(
                    schemaAttribute.Example,
                    schema,
                    context.SchemaRepository
                );
            }
        }
    }
}
