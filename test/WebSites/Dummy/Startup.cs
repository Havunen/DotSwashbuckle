using System;
using System.Globalization;
using System.IO;
using DotSwashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Dummy.Swagger;

namespace Dummy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.FullName);
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Test API V1",
                        Version = "v1",
                        Description = "A sample API for testing DotSwashbuckle",
                        TermsOfService = new Uri("http://tempuri.org/terms")
                    }
                );
                c.SwaggerDoc("doc-v1", new OpenApiInfo { Title = "doc-V1", Version = "v1" });
                c.SwaggerDoc("doc-v2", new OpenApiInfo { Title = "doc-V2", Version = "v2" });
                c.SwaggerDoc("doc-v3", new OpenApiInfo { Title = "doc-V3", Version = "v1" });
                c.SwaggerDoc("doc-v4", new OpenApiInfo { Title = "doc-V4", Version = "v2" });
                c.SwaggerDoc("doc-v5", new OpenApiInfo { Title = "doc-V5", Version = "v1" });
                c.SwaggerDoc("doc-v6", new OpenApiInfo { Title = "doc-V6", Version = "v1" });
                c.SwaggerDoc("doc-v7", new OpenApiInfo { Title = "doc-V7", Version = "v1" });
                c.SwaggerDoc("doc-v8", new OpenApiInfo { Title = "doc-V8", Version = "v1" });
                c.SwaggerDoc("doc-v9", new OpenApiInfo { Title = "doc-V9", Version = "v1" });

                c.DescribeAllParametersInCamelCase();

                c.UseOneOfForPolymorphism();
                c.UseAllOfForInheritance();

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Dummy.xml"));

                c.ExampleFilters();
                c.UseInlineDefinitionsForEnums();

                c.EnableAnnotations();
            });

            services.AddSwaggerExamples();
            services.AddSwaggerExamplesFromAssemblyOf<EtsNoticeContractExample>();
            services.AddSwaggerExamplesFromAssemblyOf<EtsNoticeSummaryExample>();
            services.AddSwaggerExamplesFromAssemblyOf<EtsCreateProcurementPlanContractExample>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Expose Swagger/OpenAPI JSON in new (v3) and old (v2) formats
                endpoints.MapSwagger("swagger/{documentName}/swagger.json");
                endpoints.MapSwagger("swagger/{documentName}/swaggerv2.json", c =>
                {
                    c.SerializeAsV2 = true;
                });
            });

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("fr"),
                new CultureInfo("sv-SE"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = ""; // serve the UI at root
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.SwaggerEndpoint("/swagger/doc-v1/swagger.json", "doc v1");
                c.SwaggerEndpoint("/swagger/doc-v2/swagger.json", "doc v2");
                c.SwaggerEndpoint("/swagger/doc-v3/swagger.json", "doc v3");
                c.SwaggerEndpoint("/swagger/doc-v4/swagger.json", "doc v4");
                c.SwaggerEndpoint("/swagger/doc-v5/swagger.json", "doc v5");
                c.SwaggerEndpoint("/swagger/doc-v6/swagger.json", "doc v6");
                c.SwaggerEndpoint("/swagger/doc-v7/swagger.json", "doc v7");
                c.SwaggerEndpoint("/swagger/doc-v8/swagger.json", "doc v8");
                c.SwaggerEndpoint("/swagger/doc-v9/swagger.json", "doc v9");
            });
        }
    }
}
