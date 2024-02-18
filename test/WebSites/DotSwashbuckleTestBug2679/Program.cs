using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OData;
using SwashbuckleTestBug2679.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddOData(option => {
        option.TimeZone = TimeZoneInfo.Utc;
        option.EnableQueryFeatures();
        option.RouteOptions.EnableKeyInParenthesis = false;
        option.RouteOptions.EnablePropertyNameCaseInsensitive = true;
    }).AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApiVersioning(options => {
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1.0);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
}).AddOData(options => {
    options.AddRouteComponents("api/v{version:ApiVersion}");
}).AddODataApiExplorer(options => {
    options.SubstituteApiVersionInUrl = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1.0);
    options.GroupNameFormat = "'v'VVV";
    options.MetadataOptions = Asp.Versioning.ApiExplorer.ODataMetadataOptions.All;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        foreach (Asp.Versioning.ApiExplorer.ApiVersionDescription description in app.DescribeApiVersions()/*.Reverse()*/) {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"api-{description.GroupName.ToLowerInvariant()}");
        }
    });
    app.UseODataRouteDebug();
}

app.UseAuthorization();

app.MapControllers();

app.Run();