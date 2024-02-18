using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class XmlCommentsParameterFilter(
        IReadOnlyDictionary<string, XmlCommentDescriptor> xmlMemberDescriptors
    ) : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (context.PropertyInfo != null)
            {
                ApplyPropertyTags(parameter, context);
            }
            else if (context.ParameterInfo != null)
            {
                ApplyParamTags(parameter, context);
            }
        }

        private void ApplyPropertyTags(OpenApiParameter parameter, ParameterFilterContext context)
        {
            var propertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(context.PropertyInfo);

            if (!xmlMemberDescriptors.TryGetValue(propertyMemberName, out var xmlCommentDesc))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(xmlCommentDesc.Summary))
            {
                parameter.Description = XmlCommentsTextHelper.Humanize(xmlCommentDesc.Summary);
                parameter.Schema.Description = null; // no need to duplicate
            }

            if (!string.IsNullOrWhiteSpace(xmlCommentDesc.Example))
            {
                parameter.Example = ExampleParser.ParseNodeExample(
                    xmlCommentDesc.Example,
                    parameter.Schema,
                    context.SchemaRepository
                );
            }
        }

        private void ApplyParamTags(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (!(context.ParameterInfo.Member is MethodInfo methodInfo)) return;

            // If method is from a constructed generic type, look for comments from the generic type method
            var targetMethod = methodInfo.DeclaringType?.IsConstructedGenericType == true
                ? methodInfo.GetUnderlyingGenericTypeMethod()
                : methodInfo;

            if (targetMethod == null) return;

            var methodMemberName = XmlCommentsNodeNameHelper.GetMemberNameForMethod(targetMethod);

            if (!xmlMemberDescriptors.TryGetValue(methodMemberName, out var xmlCommentDesc))
            {
                return;
            }

            var paramNode = xmlCommentDesc.Params?.FirstOrDefault(p => string.Equals(p.Name, context.ParameterInfo.Name, StringComparison.Ordinal));

            if (paramNode != null)
            {
                parameter.Description = XmlCommentsTextHelper.Humanize(paramNode.Value);

                if (string.IsNullOrWhiteSpace(paramNode.Example)) return;

                parameter.Example = ExampleParser.ParseNodeExample(
                    paramNode.Example,
                    parameter.Schema,
                    context.SchemaRepository
                );
            }
        }
    }
}
