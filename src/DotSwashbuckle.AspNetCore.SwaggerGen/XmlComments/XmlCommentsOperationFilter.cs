using System;
using System.Collections.Generic;
using System.Reflection;
using DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class XmlCommentsOperationFilter(
        IReadOnlyDictionary<string, XmlCommentDescriptor> xmlMemberDescriptors
    ) : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo == null) return;

            // If method is from a constructed generic type, look for comments from the generic type method
            var targetMethod = context.MethodInfo.DeclaringType?.IsConstructedGenericType == true
                ? context.MethodInfo.GetUnderlyingGenericTypeMethod()
                : context.MethodInfo;

            if (targetMethod == null) return;

            ApplyControllerTags(operation, targetMethod.DeclaringType);
            ApplyMethodTags(operation, targetMethod);
        }

        private void ApplyControllerTags(OpenApiOperation operation, Type controllerType)
        {
            var typeMemberName = XmlCommentsNodeNameHelper.GetMemberNameForType(controllerType);

            if (!xmlMemberDescriptors.TryGetValue(typeMemberName, out var xmlCommentDescriptor))
            {
                return;
            }

            ApplyResponseTags(operation, xmlCommentDescriptor);
        }

        private void ApplyMethodTags(OpenApiOperation operation, MethodInfo methodInfo)
        {
            var methodMemberName = XmlCommentsNodeNameHelper.GetMemberNameForMethod(methodInfo);

            if (!xmlMemberDescriptors.TryGetValue(methodMemberName, out var xmlCommentDescriptor))
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Summary))
                operation.Summary = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Summary);

            if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Remarks))
                operation.Description = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Remarks);

            ApplyResponseTags(operation, xmlCommentDescriptor);
        }

        private void ApplyResponseTags(OpenApiOperation operation, XmlCommentDescriptor xmlCommentDescriptor)
        {
            if (xmlCommentDescriptor.Responses == null) return;

            foreach (var xmlResponse in xmlCommentDescriptor.Responses)
            {
                var response = operation.Responses.ContainsKey(xmlResponse.Code)
                    ? operation.Responses[xmlResponse.Code]
                    : operation.Responses[xmlResponse.Code] = new OpenApiResponse();

                response.Description = XmlCommentsTextHelper.Humanize(xmlResponse.Description);
            }
        }
    }
}