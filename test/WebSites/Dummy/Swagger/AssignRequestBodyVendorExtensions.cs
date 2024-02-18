using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.SwaggerGen;

namespace Dummy.Swagger
{
    public class AssignRequestBodyVendorExtensions : IRequestBodyFilter
    {
        public void Apply(OpenApiRequestBody requestBody, RequestBodyFilterContext context)
        {
            requestBody.Extensions.Add("x-purpose", new OpenApiString("test"));
        }
    }
}
