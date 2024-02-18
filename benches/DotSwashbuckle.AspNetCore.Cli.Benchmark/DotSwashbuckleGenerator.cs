using DotSwashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using System.Globalization;

namespace DotSwashbuckle.AspNetCore.Cli.Benchmark
{
    internal class DotSwashbuckleGenerator
    {

        public static string CreateSwaggerDoc(IServiceProvider serviceProvider, bool isYaml, bool isV2)
        {
            // 3) Retrieve Swagger via configured provider
            var swaggerProvider = serviceProvider.GetRequiredService<ISwaggerProvider>();
            var swagger = swaggerProvider.GetSwagger(
                "v1",
                null,
                null
            );

            using (var streamWriter = (new StringWriter(CultureInfo.InvariantCulture)))
            {
                IOpenApiWriter writer;
                if (isYaml)
                    writer = new OpenApiYamlWriter(streamWriter);
                else
                    writer = new OpenApiJsonWriter(streamWriter);

                if (isV2)
                    swagger.SerializeAsV2(writer);
                else
                    swagger.SerializeAsV3(writer);

                return streamWriter.ToString();
            }
        }

    }
}
