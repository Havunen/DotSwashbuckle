using System;
using System.Globalization;
using System.IO;
using Basic.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Localization;
using Basic.Swagger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic
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

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SupportNonNullableReferenceTypes();
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Test API V1",
                        Version = "v1",
                        Description = "A sample API for testing DotSwashbuckle",
                        TermsOfService = new Uri("http://tempuri.org/terms")
                    }
                );

                c.RequestBodyFilter<AssignRequestBodyVendorExtensions>();

                c.OperationFilter<AssignOperationVendorExtensions>();

                c.SchemaFilter<ExamplesSchemaFilter>();

                c.DescribeAllParametersInCamelCase();

                c.UseOneOfForPolymorphism();
                c.UseAllOfForInheritance();

                c.SelectDiscriminatorNameUsing((baseType) => "TypeName");
                c.SelectDiscriminatorValueUsing((subType) => subType.Name);

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Basic.xml"));

                c.EnableAnnotations();
            });
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

                endpoints.MapPost("/requestWithNestedChild", (Requests.RequestWithNestedChild request) => "ok").WithOpenApi();
                endpoints.MapPost("/requestWithNestedChild2", (Requests.RequestWithNestedChild request) => "ok");
                endpoints.MapPost("/requestWithNonNestedChild", (Requests.RequestWithNonNestedChild request) => "ok").WithOpenApi();
                endpoints.MapPost("/requestWithNonNestedChild2", (Requests.RequestWithNonNestedChild request) => "ok");

                endpoints.MapPost("/formpost/minimalPost", ([FromForm] WeatherForecast person, [FromForm] Product address, [FromQuery] string ts)
                        => TypedResults.NoContent())
                    .WithOpenApi();

                endpoints.MapPost("/formpost/minimalPost2", ([FromForm] WeatherForecast person, [FromForm] Product address, [FromQuery] string ts)
                        => TypedResults.NoContent())
                    .WithOpenApi();

                endpoints.MapGet("/formpost/minimalGet", ([FromForm] WeatherForecast person, [FromForm] Product address, [FromQuery] string ts)
                        => TypedResults.NoContent())
                    .WithOpenApi();

                endpoints.MapGet("/formpost/minimalGet2",
                    ([FromForm] WeatherForecast person, [FromForm] Product address, [FromQuery] string ts)
                        => TypedResults.NoContent());

                endpoints.MapPost("/formpost/fromheader", ([FromHeader(Name = "x-api-version")] string apiVersion)
                        => TypedResults.NoContent())
                    .WithOpenApi();

                endpoints.MapPost("/formpost/fromheader2", ([FromHeader(Name = "x-api-version")] string apiVersion)
                    => TypedResults.NoContent());

                endpoints.MapGet("/asparameter/openapi/enum", ([FromQuery] ConditionState? ConditionStateFromQuery,
                    [AsParameters] RequestModel model) =>
                {
                    return $"{ConditionStateFromQuery}, {model.ConditionStateAsParameters}";
                }).WithOpenApi();

                endpoints.MapGet("/asparameter/openapi/enum2", ([FromQuery] ConditionState? ConditionStateFromQuery,
                    [AsParameters] RequestModel model) =>
                {
                    return $"{ConditionStateFromQuery}, {model.ConditionStateAsParameters}";
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }

        public class Requests
        {
            public record RequestWithNestedChild(RequestWithNestedChild.NestedChild Child)
            {
                public record NestedChild(string NonNullable, string? Nullable);
            }

            public record RequestWithNonNestedChild(Child Child);
            public record Child(string NonNullable, string? Nullable);
        }

        public class RequestModel
        {
            public ConditionState? ConditionStateAsParameters { get; init; }
            public Guid? SomeId { get; set; }
            public string? SomeFilter { get; set; }
            public decimal SomeDecimal { get; set; }
        }

        public enum ConditionState
        {
            Both,
            False,
            True
        }

    }
}
