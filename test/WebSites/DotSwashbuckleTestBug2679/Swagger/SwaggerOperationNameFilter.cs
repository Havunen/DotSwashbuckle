using DotSwashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace SwashbuckleTestBug2679.Swagger {
    public class SwaggerOperationNameFilter : IOperationFilter {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            string oldOperationId = operation.OperationId;
            //TODO(demarco): Should be "{Last Controller Operation} {End of OperationId}" => "Get /authors/$count"
            operation.OperationId = $"{context.ApiDescription.ActionDescriptor.DisplayName}_{GetOpertationId(operation,context)}";
            //operation.Description = $"Get {oldOperationId}";
        } 

        private String GetOpertationId(OpenApiOperation operation, OperationFilterContext context) {
            String result = operation.OperationId;
            if (String.IsNullOrEmpty(result)) {
                result = $"{(12582917 * operation.Parameters.Count()) + (6291469 * context.ApiDescription.ActionDescriptor.Parameters.Count())}";
            }
            return result;
        }

    }
}
