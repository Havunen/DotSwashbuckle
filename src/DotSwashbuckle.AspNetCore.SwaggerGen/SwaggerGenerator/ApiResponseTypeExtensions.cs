using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public static class ApiResponseTypeExtensions
    {
        internal static bool IsDefaultResponse(this ApiResponseType apiResponseType)
        {
            var propertyInfo = apiResponseType.GetType().GetProperty("IsDefaultResponse");
            if (propertyInfo != null)
            {
                return (bool)propertyInfo.GetValue(apiResponseType);
            }

            return false;
        }
    }
}
