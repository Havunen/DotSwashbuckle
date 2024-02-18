using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using DotSwashbuckle.AspNetCore.SwaggerGen;
using DotSwashbuckle.AspNetCore.Annotations;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AnnotationsSwaggerGenOptionsExtensions
    {
        /// <summary>
        /// Enables Swagger annotations (SwaggerOperationAttribute, SwaggerParameterAttribute etc.)
        /// </summary>
        /// <param name="options"></param>
        /// <param name="enableAnnotationsForInheritance">Enables SwaggerSubType attribute for inheritance</param>
        /// <param name="enableAnnotationsForPolymorphism">Enables SwaggerSubType and SwaggerDiscriminator attributes for polymorphism</param>
        public static void EnableAnnotations(
            this SwaggerGenOptions options,
            bool enableAnnotationsForInheritance,
            bool enableAnnotationsForPolymorphism)
        {
            options.SchemaFilter<AnnotationsSchemaFilter>();
            options.ParameterFilter<AnnotationsParameterFilter>();
            options.RequestBodyFilter<AnnotationsRequestBodyFilter>();
            options.OperationFilter<AnnotationsOperationFilter>();
            options.DocumentFilter<AnnotationsDocumentFilter>();

            if (enableAnnotationsForInheritance || enableAnnotationsForPolymorphism)
            {
                options.SelectSubTypesUsing(AnnotationsSubTypesSelector);
                options.SelectDiscriminatorNameUsing(AnnotationsDiscriminatorNameSelector);
                options.SelectDiscriminatorValueUsing(AnnotationsDiscriminatorValueSelector);

                if (enableAnnotationsForInheritance)
                {
                    options.UseAllOfForInheritance();
                }

                if (enableAnnotationsForPolymorphism)
                {
                    options.UseOneOfForPolymorphism();
                }
            }
        }

        /// <summary>
        /// Enables Swagger annotations (SwaggerOperationAttribute, SwaggerParameterAttribute etc.)
        /// </summary>
        /// <param name="options"></param>
        public static void EnableAnnotations(this SwaggerGenOptions options)
        {
            options.EnableAnnotations(
                enableAnnotationsForPolymorphism: false,
                enableAnnotationsForInheritance: false);
        }

        private static IEnumerable<Type> AnnotationsSubTypesSelector(Type type)
        {
            var jsonDerivedTypeAttributes = type.GetCustomAttributes(false)
                .OfType<JsonDerivedTypeAttribute>()
                .ToArray();

            if (jsonDerivedTypeAttributes.Any())
            {
                return jsonDerivedTypeAttributes.Select(attr => attr.DerivedType);
            }

            return Enumerable.Empty<Type>();
        }

        private static string AnnotationsDiscriminatorNameSelector(Type baseType)
        {
            var jsonPolymorphicAttribute = baseType.GetCustomAttributes(false)
                .OfType<JsonPolymorphicAttribute>()
                .FirstOrDefault();

            if (jsonPolymorphicAttribute is not null)
            {
                return jsonPolymorphicAttribute.TypeDiscriminatorPropertyName;
            }

            return null;
        }

        private static string AnnotationsDiscriminatorValueSelector(Type subType)
        {
            if (subType.BaseType == null)
                return null;

            var jsonDerivedTypeAttribute = subType.BaseType.GetCustomAttributes(false)
                .OfType<JsonDerivedTypeAttribute>()
                .FirstOrDefault(attr => attr.DerivedType == subType);

            if (jsonDerivedTypeAttribute is not null)
            {
                return jsonDerivedTypeAttribute.TypeDiscriminator?.ToString();
            }

            return null;
        }
    }
}
