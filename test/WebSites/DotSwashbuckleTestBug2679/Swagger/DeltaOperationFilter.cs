using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwashbuckleTestBug2679.Swagger {
    public class DeltaOperationFilter : IOperationFilter {

        private readonly String _deltaWrapper = typeof(Delta<>).FullName ?? throw new ArgumentNullException(typeof(Delta<>).Name); // "Microsoft.AspNet.OData.Delta`1";
        private readonly String _assemblyName = typeof(Delta).Assembly.FullName ?? throw new ArgumentNullException(nameof(Delta));

        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            if (operation.RequestBody == null) return;

            IEnumerable<KeyValuePair<String, OpenApiMediaType>> deltaTypes = operation.RequestBody.Content.Where(x => x.Value.Schema.Reference.Id.StartsWith(_deltaWrapper));

            foreach ((String _, OpenApiMediaType value) in deltaTypes) {
                OpenApiSchema schema = value.Schema;
                var deltaType = Type.GetType(schema.Reference.Id + ", " + _assemblyName);
                Type? deltaArgument = deltaType?.GetGenericArguments().First();
                schema.Reference.Id = deltaArgument?.FullName ?? schema.Reference.Id;
            }
        }

        //public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context) {

        //}
    }
}
