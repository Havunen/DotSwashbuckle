using System;
using System.Collections.Generic;
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

            if (!xmlMemberDescriptors.TryGetValue(fieldOrPropertyMemberName, out var xmlCommentDescriptor))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Summary))
                schema.Description = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Summary);

            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Example))
            {
                schema.Example = ExampleParser.ParseNodeExample(
                    xmlCommentDescriptor.Example,
                    schema,
                    context.SchemaRepository
                );
            }
        }
    }
}
