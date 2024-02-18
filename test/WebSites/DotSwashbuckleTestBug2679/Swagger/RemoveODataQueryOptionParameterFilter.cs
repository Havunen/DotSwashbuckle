using DotSwashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace SwashbuckleTestBug2679.Swagger {
    public class RemoveODataQueryOptionParameterFilter : IOperationFilter {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            OpenApiParameter? versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "queryOptions");
            if (versionParameter != null) { operation.Parameters.Remove(versionParameter); }

            //TODO(demarco): we need to find a way to add the $ as a prefix but this solution transform the $
            //OpenApiParameter? selectParameter = operation.Parameters.SingleOrDefault(p => p.Name == "select");
            //if (selectParameter != null) { selectParameter.Name = "$select"; }
        }
    }
}
