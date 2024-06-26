﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.SwaggerGen;

namespace Basic.Swagger
{
    public class AssignOperationVendorExtensions : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Extensions["x-purpose"] = new OpenApiString("test");
        }
    }
}
