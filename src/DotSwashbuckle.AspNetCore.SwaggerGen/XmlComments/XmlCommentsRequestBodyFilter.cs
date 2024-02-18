using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class XmlCommentsRequestBodyFilter(
        IReadOnlyDictionary<string, XmlCommentDescriptor> xmlMemberDescriptors
    ) : IRequestBodyFilter
    {

        public void Apply(OpenApiRequestBody requestBody, RequestBodyFilterContext context)
        {
            var bodyParameterDescription = context.BodyParameterDescription;

            if (bodyParameterDescription == null) return;

            var propertyInfo = bodyParameterDescription.PropertyInfo();
            if (propertyInfo != null)
            {
                ApplyPropertyTags(requestBody, context, propertyInfo);
                return;
            }

            var parameterInfo = bodyParameterDescription.ParameterInfo();
            if (parameterInfo != null)
            {
                ApplyParamTags(requestBody, context, parameterInfo);
                return;
            }
        }

        private void ApplyPropertyTags(OpenApiRequestBody requestBody, RequestBodyFilterContext context, PropertyInfo propertyInfo)
        {
            var propertyMemberName = XmlCommentsNodeNameHelper.GetMemberNameForFieldOrProperty(propertyInfo);

            if (!xmlMemberDescriptors.TryGetValue(propertyMemberName, out var xmlCommentDescriptor))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Summary))
                requestBody.Description = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Summary);


            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Example))
            {
                foreach (var mediaType in requestBody.Content.Values)
                {
                    mediaType.Example = ExampleParser.ParseNodeExample(
                        xmlCommentDescriptor.Example,
                        mediaType.Schema,
                        context.SchemaRepository
                    );
                }
            }
        }

        private void ApplyParamTags(OpenApiRequestBody requestBody, RequestBodyFilterContext context, ParameterInfo parameterInfo)
        {
            if (!(parameterInfo.Member is MethodInfo methodInfo)) return;

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

            var paramNode = xmlCommentDesc.Params?.FirstOrDefault(p => string.Equals(p.Name, parameterInfo.Name, StringComparison.Ordinal));

            if (paramNode != null)
            {
                requestBody.Description = XmlCommentsTextHelper.Humanize(paramNode.Value);

                var example = paramNode.Example;
                if (string.IsNullOrWhiteSpace(example))
                {
                    return;
                }

                foreach (var mediaType in requestBody.Content.Values)
                {
                    mediaType.Example = ExampleParser.ParseNodeExample(
                        example,
                        mediaType.Schema,
                        context.SchemaRepository
                    );
                }
            }
        }
    }
}
