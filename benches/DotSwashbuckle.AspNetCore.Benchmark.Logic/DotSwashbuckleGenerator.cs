using DotSwashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using System.Globalization;

namespace DotSwashbuckle.AspNetCore.Benchmark.Logic
{
    public class DotSwashbuckleGenerator
    {

        public static async Task<string> CreateSwaggerDoc(
            IServiceProvider serviceProvider,
            bool isYaml,
            bool isV2,
            string documentName
        )
        {
            // 3) Retrieve Swagger via configured provider
            var swaggerProvider = serviceProvider.GetRequiredService<ISwaggerProvider>();
            var swagger = await swaggerProvider.GetSwaggerAsync(
                documentName,
                null,
                null
            );

            using (var streamWriter = new StringWriter(CultureInfo.InvariantCulture))
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
