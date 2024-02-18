using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using DotSwashbuckle.AspNetCore.SwaggerGen;

namespace SwashbuckleTestBug2679.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {

        //private readonly IApiVersionDescriptionProvider _provider;
        private readonly SwashbuckleSchemaHelper _swashbuckleSchemaHelper = new SwashbuckleSchemaHelper();

        //public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        //{
        //    _provider = provider;
        //}

        public void Configure(string? name, SwaggerGenOptions options) => Configure(options);
        public void Configure(SwaggerGenOptions options)
        {

            Assembly? entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                //String pathToXmlComments = Path.Combine(
                //       $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}",
                //       $"{typeof(CheckMateBuilderExtensionsCore).Assembly.GetName().Name}.xml"
                //   );
                string pathToXmlComments = Path.Combine(
                       $"{Path.GetDirectoryName(entryAssembly.Location)}",
                       $"{entryAssembly.GetName().Name}.xml"
                   );

                if (File.Exists(pathToXmlComments))
                {
                    options.IncludeXmlComments(pathToXmlComments);
                }
            }

            //options.SwaggerDoc("latest", CreateVersionInfo(new ApiVersionDescription(new ApiVersion(0, 0, "latest"), "latest", false)));
            //foreach (var description in _provider.ApiVersionDescriptions)
            //{
            //    options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            //}

            //options.DocumentFilter<VersionedMetadataControllerFilter>();

            options.OperationFilter<SwaggerDefaultValues>();
            options.OperationFilter<RemoveODataQueryOptionParameterFilter>();
            options.OperationFilter<SwaggerOperationNameFilter>();
            //options.OperationFilter<DeltaOperationFilter>();

            //options.DocumentFilter<RemoveLatestVersionApiFilter>();

            // ?????
            options.EnableAnnotations();

            //options.ResolveConflictingActions(p => {
            //    Console.WriteLine($"[DEBUG] - Swagger, List all ConflictingActions : ");
            //    foreach(var item in p) {
            //        Console.WriteLine($"item: {item.GroupName}, {item.SupportedResponseTypes}, {item.SupportedRequestFormats}, {item.ParameterDescriptions}, {item.HttpMethod}, {item.RelativePath}");
            //    }
            //    Console.WriteLine($"[DEBUG] --- ");
            //    return p.First();
            //});

            //options.ResolveConflictingActions(p => p.First());

            //options.AddServer(new OpenApiServer() { });
            //options.DocInclusionPredicate(_AppDocInclusionPredicate.Filter);

            options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme."
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                    },
                    new string[] {}
                }
            });
            options.CustomSchemaIds(type => _swashbuckleSchemaHelper.GetSchemaId(type));
            //options.CustomSchemaIds(type => type.FullName);
        }

        private static OpenApiInfo CreateVersionInfo()
        {
            var info = new OpenApiInfo()
            {
                Title = "CheckMate API",
                Version = "1",
                //Description = "A sample application with Swagger, Swashbuckle, and API versioning.",
                //Contact = new OpenApiContact() { Name = "Bill Mei", Email = "bill.mei@somewhere.com" },
                //License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            //if (description.IsDeprecated)
            //{
            //    info.Description += " This API version has been deprecated.";
            //}

            return info;
        }

    }
}
