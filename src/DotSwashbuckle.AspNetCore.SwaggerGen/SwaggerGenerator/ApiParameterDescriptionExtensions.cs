using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Net.Http.Headers;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public static class ApiParameterDescriptionExtensions
    {
        private static readonly HashSet<string> IllegalHeaderParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            HeaderNames.Accept,
            HeaderNames.Authorization,
            HeaderNames.ContentType
        };

        public static bool IsRequiredParameter(this ApiParameterDescription apiParameter)
        {
            // From the OpenAPI spec:
            // If the parameter location is "path", this property is REQUIRED and its value MUST be true.
            if (apiParameter.IsFromPath())
            {
                return true;
            }

            // This is to keep compatibility with MVC controller logic that has existed in the past
            if (apiParameter.ParameterDescriptor is ControllerParameterDescriptor)
            {
                // This is the default logic for IsRequired
                return apiParameter.CustomAttributes().Any(attr => attr is BindRequiredAttribute or RequiredAttribute or RequiredMemberAttribute);
            }

            return apiParameter.IsRequired;
        }

        public static ParameterInfo ParameterInfo(this ApiParameterDescription apiParameter)
        {
            var parameterDescriptor = apiParameter.ParameterDescriptor as
                Microsoft.AspNetCore.Mvc.Infrastructure.IParameterInfoParameterDescriptor;


            return parameterDescriptor?.ParameterInfo;
        }

        public static PropertyInfo PropertyInfo(this ApiParameterDescription apiParameter)
        {
            var modelMetadata = apiParameter.ModelMetadata;

            if (modelMetadata?.ContainerType != null)
            {
                PropertyInfo propertyInfo = modelMetadata.ContainerType.GetProperty(modelMetadata.PropertyName);

                if (propertyInfo != null)
                {
                    return propertyInfo;
                }

                foreach (var type in modelMetadata.ContainerType.GetInterfaces())
                {
                    propertyInfo = type.GetProperty(modelMetadata.PropertyName);

                    if (propertyInfo != null)
                    {
                        return propertyInfo;
                    }
                }
            }

            return null;
        }

        public static IEnumerable<object> CustomAttributes(this ApiParameterDescription apiParameter)
        {
            var propertyInfo = apiParameter.PropertyInfo();
            if (propertyInfo != null) return propertyInfo.GetCustomAttributes(true);

            var parameterInfo = apiParameter.ParameterInfo();
            if (parameterInfo != null) return parameterInfo.GetCustomAttributes(true);

            return Enumerable.Empty<object>();
        }

        internal static bool IsFromPath(this ApiParameterDescription apiParameter)
        {
            return apiParameter.Source == BindingSource.Path;
        }

        internal static bool IsFromBody(this ApiParameterDescription apiParameter)
        {
            return apiParameter.Source == BindingSource.Body;
        }

        internal static bool IsFromForm(this ApiParameterDescription apiParameter)
        {
            var source = apiParameter.Source;
            var elementType = apiParameter.ModelMetadata?.ElementType;

            return source == BindingSource.Form || source == BindingSource.FormFile
                || (elementType != null && typeof(IFormFile).IsAssignableFrom(elementType));
        }

        internal static bool IsIllegalHeaderParameter(this ApiParameterDescription apiParameter)
        {
            // Certain header parameters are not allowed and should be described using the corresponding OpenAPI keywords
            // https://swagger.io/docs/specification/describing-parameters/#header-parameters
            return apiParameter.Source == BindingSource.Header && IllegalHeaderParameters.Contains(apiParameter.Name);
        }
    }
}