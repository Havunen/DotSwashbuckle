using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using System;
using DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class XmlCommentsDocumentFilter(
        IReadOnlyDictionary<string, XmlCommentDescriptor> xmlMemberDescriptors
    ) : IDocumentFilter
    {

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // Collect (unique) controller names and types in a dictionary
            var controllerNamesAndTypes = context.ApiDescriptions
                .Select(apiDesc => apiDesc.ActionDescriptor as ControllerActionDescriptor)
                .Where(actionDesc => actionDesc != null)
                .GroupBy(actionDesc => actionDesc.ControllerName)
                .Select(group => new KeyValuePair<string, Type>(group.Key, group.First().ControllerTypeInfo.AsType()));

            foreach (var nameAndType in controllerNamesAndTypes)
            {
                var memberName = XmlCommentsNodeNameHelper.GetMemberNameForType(nameAndType.Value);

                if (!xmlMemberDescriptors.TryGetValue(memberName, out var xmlCommentDescriptor))
                {
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(xmlCommentDescriptor.Summary))
                {
                    swaggerDoc.Tags ??= new List<OpenApiTag>();

                    swaggerDoc.Tags.Add(new OpenApiTag
                    {
                        Name = nameAndType.Key,
                        Description = XmlCommentsTextHelper.Humanize(xmlCommentDescriptor.Summary)
                    });
                }
            }
        }
    }
}
