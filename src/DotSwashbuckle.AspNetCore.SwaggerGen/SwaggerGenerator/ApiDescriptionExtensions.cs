using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing.Template;
using System.Text;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public static class ApiDescriptionExtensions
    {
        public static bool TryGetMethodInfo(this ApiDescription apiDescription, out MethodInfo methodInfo)
        {
            if (apiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                methodInfo = controllerActionDescriptor.MethodInfo;
                return true;
            }

            if (apiDescription.ActionDescriptor?.EndpointMetadata != null)
            {
                methodInfo = apiDescription.ActionDescriptor.EndpointMetadata
                    .OfType<MethodInfo>()
                    .FirstOrDefault();

                return methodInfo != null;
            }

            methodInfo = null;
            return false;
        }

        public static IEnumerable<object> CustomAttributes(this ApiDescription apiDescription)
        {
            if (apiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
            {
                return methodInfo.GetCustomAttributes(true)
                    .Union(methodInfo.DeclaringType.GetCustomAttributes(true));
            }

            return Enumerable.Empty<object>();
        }

        internal static string RelativePathSansParameterConstraints(this ApiDescription apiDescription)
        {
            var routeTemplate = apiDescription.RelativePath!;

            // remove query string parameters
            var modifiedTemplate = new StringBuilder(routeTemplate.Length);
            var isBetweenCurlyBraces = false;

            foreach (var current in routeTemplate)
            {
                if (current == '{')
                {
                    isBetweenCurlyBraces = true;
                } else if (current == '}')
                {
                    isBetweenCurlyBraces = false;
                } else if (!isBetweenCurlyBraces && current == '?')
                {
                    break;
                }

                modifiedTemplate.Append(current);
            }

            var parsedRouteTemplate = TemplateParser.Parse(modifiedTemplate.ToString());
            var sanitizedSegments = parsedRouteTemplate
                .Segments
                .Select(s => string.Concat(s.Parts.Select(p => p.Name != null ? $"{{{p.Name}}}" : p.Text)));

            return string.Join("/", sanitizedSegments);
        }
    }
}
