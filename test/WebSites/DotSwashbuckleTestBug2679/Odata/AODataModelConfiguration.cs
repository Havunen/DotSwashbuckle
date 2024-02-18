using Asp.Versioning;
using Asp.Versioning.OData;
using Microsoft.OData.ModelBuilder;

namespace SwashbuckleTestBug2679.Odata {
    public class AODataModelConfiguration : IModelConfiguration {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, String? routePrefix) {
            builder.EntitySet<DtoA>("a");
        }
    }
}
