using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    public class TestRequestBodyFilter : IRequestBodyFilter
    {
        public void Apply(OpenApiRequestBody requestBody, RequestBodyFilterContext context)
        {
            requestBody.Extensions.Add("X-foo", new OpenApiString("bar"));
            requestBody.Extensions.Add("X-docName", new OpenApiString(context.DocumentName));
        }
    }
}