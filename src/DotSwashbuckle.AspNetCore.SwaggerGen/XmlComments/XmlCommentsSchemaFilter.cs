using System;
using System.Collections.Generic;
using System.Linq;
using DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class XmlCommentsSchemaFilter(
        IReadOnlyDictionary<string, XmlCommentDescriptor> xmlMemberDescriptors
    ) : ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            ApplyTypeTags(schema, context.Type);

            if (context.MemberInfo != null)
            {
                ApplyMemberTags(schema, context);
            }
        }

        private void ApplyTypeTags(OpenApiSchema schema, Type type)
        {
            var typeMemberName = XmlCommentsNodeNameHelper.GetMemberNameForType(type);

            if (!xmlMemberDescriptors.TryGetValue(typeMemberName, out var xmlCommentDescriptor))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Remarks))
            {
                schema.Description = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Remarks);
            }

            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Summary))
            {
                if (schema.Description == null)
                {
                    schema.Description = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Summary);
                }
                else
                {
                    schema.Title = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Summary);
                }
            }
        }

        private void ApplyMemberTags(OpenApiSchema schema, SchemaFilterContext context)
        {
            var fieldOrPropertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(context.MemberInfo);

            if (!xmlMemberDescriptors.TryGetValue(fieldOrPropertyMemberName, out var fieldXmlInfo))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(fieldXmlInfo.Summary))
                schema.Description = XmlCommentsTextHelper.Humanize(fieldXmlInfo.Summary);

            if (!string.IsNullOrWhiteSpace(fieldXmlInfo.Example))
            {
                schema.Example = ExampleParser.ParseNodeExample(
                    fieldXmlInfo.Example,
                    schema,
                    context.SchemaRepository
                );
            }
            else if (context.MemberInfo.DeclaringType != null)
            {
                var declaringType = XmlCommentsNodeNameHelper.GetMemberNameForType(context.MemberInfo.DeclaringType);

                if (!xmlMemberDescriptors.TryGetValue(declaringType, out var declaringTypeXmlInfo))
                {
                    return;
                }

                var paramNode = declaringTypeXmlInfo.Params?.FirstOrDefault(p => string.Equals(p.Name, context.MemberInfo.Name, StringComparison.Ordinal));

                if (paramNode != null && !string.IsNullOrWhiteSpace(paramNode.Example))
                {
                    schema.Example = ExampleParser.ParseNodeExample(
                        paramNode.Example,
                        schema,
                        context.SchemaRepository
                    );
                }
            }
        }
    }
}
