using System.Text.RegularExpressions;
using DotSwashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace SwashbuckleTestBug2679.Swagger {
    public class RemoveLatestVersionApiFilter : IDocumentFilter {

        private static readonly Regex _checkPathContainsVersion = new Regex(@"^\/api\/v\d+(\.\d+)?");

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context) {
            foreach (var path in swaggerDoc.Paths.ToList()) {
                if (!_checkPathContainsVersion.IsMatch(path.Key)) {
                    swaggerDoc.Paths.Remove(path.Key);
                }
            }
        }
    }
}
