﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class SwaggerGenerator : ISwaggerProvider, IAsyncSwaggerProvider
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionsProvider;
        private readonly ISchemaGenerator _schemaGenerator;
        private readonly SwaggerGeneratorOptions _options;
        private readonly IAuthenticationSchemeProvider _authenticationSchemeProvider;

        public SwaggerGenerator(
            IOptions<SwaggerGeneratorOptions> generatorOptions,
            IApiDescriptionGroupCollectionProvider apiDescriptionsProvider,
            ISchemaGenerator schemaGenerator)
        {
            _options = generatorOptions.Value;
            _apiDescriptionsProvider = apiDescriptionsProvider;
            _schemaGenerator = schemaGenerator;
        }

        public SwaggerGenerator(
            IOptions<SwaggerGeneratorOptions> generatorOptions,
            IApiDescriptionGroupCollectionProvider apiDescriptionsProvider,
            ISchemaGenerator schemaGenerator,
            IAuthenticationSchemeProvider authenticationSchemeProvider) : this(generatorOptions, apiDescriptionsProvider, schemaGenerator)
        {
            _authenticationSchemeProvider = authenticationSchemeProvider;
        }

        public async Task<OpenApiDocument> GetSwaggerAsync(string documentName, string host = null, string basePath = null)
        {
            var (applicableApiDescriptions, swaggerDoc, schemaRepository) = GetSwaggerDocumentWithoutFilters(documentName, host, basePath);

            swaggerDoc.Components.SecuritySchemes = await GetSecuritySchemes();

            // NOTE: Filter processing moved here so they may effect generated security schemes
            var filterContext = new DocumentFilterContext(applicableApiDescriptions, _schemaGenerator, schemaRepository);
            foreach (var filter in _options.DocumentFilters)
            {
                filter.Apply(swaggerDoc, filterContext);
            }

            swaggerDoc.Components.Schemas = new SortedDictionary<string, OpenApiSchema>(swaggerDoc.Components.Schemas, _options.SchemaComparer);

            return swaggerDoc;
        }

        public OpenApiDocument GetSwagger(string documentName, string host = null, string basePath = null)
        {
            var (applicableApiDescriptions, swaggerDoc, schemaRepository) = GetSwaggerDocumentWithoutFilters(documentName, host, basePath);

            swaggerDoc.Components.SecuritySchemes = GetSecuritySchemes().Result;

            // NOTE: Filter processing moved here so they may effect generated security schemes
            var filterContext = new DocumentFilterContext(applicableApiDescriptions, _schemaGenerator, schemaRepository);
            foreach (var filter in _options.DocumentFilters)
            {
                filter.Apply(swaggerDoc, filterContext);
            }

            swaggerDoc.Components.Schemas = new SortedDictionary<string, OpenApiSchema>(swaggerDoc.Components.Schemas, _options.SchemaComparer);

            return swaggerDoc;
        }

        private (IEnumerable<ApiDescription>, OpenApiDocument, SchemaRepository) GetSwaggerDocumentWithoutFilters(string documentName, string host = null, string basePath = null)
        {
            if (!_options.SwaggerDocs.TryGetValue(documentName, out OpenApiInfo info))
                throw new UnknownSwaggerDocument(documentName, _options.SwaggerDocs.Select(d => d.Key));

            var applicableApiDescriptions = _apiDescriptionsProvider.ApiDescriptionGroups.Items
                .SelectMany(group => group.Items)
                .Where(apiDesc => !(_options.IgnoreObsoleteActions && apiDesc.CustomAttributes().OfType<ObsoleteAttribute>().Any()))
                .Where(apiDesc => _options.DocInclusionPredicate(documentName, apiDesc));

            var schemaRepository = new SchemaRepository(documentName);

            var swaggerDoc = new OpenApiDocument
            {
                Info = info,
                Servers = GenerateServers(host, basePath),
                Paths = GeneratePaths(applicableApiDescriptions, schemaRepository),
                Components = new OpenApiComponents
                {
                    Schemas = schemaRepository.Schemas,
                },
                SecurityRequirements = new List<OpenApiSecurityRequirement>(_options.SecurityRequirements)
            };

            return (applicableApiDescriptions, swaggerDoc, schemaRepository);
        }

        private async Task<IDictionary<string, OpenApiSecurityScheme>> GetSecuritySchemes()
        {
            if (!_options.InferSecuritySchemes)
            {
                return new Dictionary<string, OpenApiSecurityScheme>(_options.SecuritySchemes);
            }

            var authenticationSchemes = _authenticationSchemeProvider is not null
                ? await _authenticationSchemeProvider.GetAllSchemesAsync()
                : Enumerable.Empty<AuthenticationScheme>();

            if (_options.SecuritySchemesSelector != null)
            {
                return _options.SecuritySchemesSelector(authenticationSchemes);
            }

            // Default implementation, currently only supports JWT Bearer scheme
            return authenticationSchemes
                .Where(authScheme => authScheme.Name == "Bearer")
                .ToDictionary(
                    (authScheme) => authScheme.Name,
                    (authScheme) => new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer", // "bearer" refers to the header name here
                        In = ParameterLocation.Header,
                        BearerFormat = "Json Web Token"
                    });
        }

        private IList<OpenApiServer> GenerateServers(string host, string basePath)
        {
            if (_options.Servers.Any())
            {
                return new List<OpenApiServer>(_options.Servers);
            }

            return host == null && basePath == null
                ? new List<OpenApiServer>()
                : new List<OpenApiServer> { new OpenApiServer { Url = $"{host}{basePath}" } };
        }

        private OpenApiPaths GeneratePaths(IEnumerable<ApiDescription> apiDescriptions, SchemaRepository schemaRepository)
        {
            var apiDescriptionsByPath = apiDescriptions
                .OrderBy(_options.SortKeySelector)
                .GroupBy(apiDesc => apiDesc.RelativePathSansParameterConstraints());

            var paths = new OpenApiPaths();
            foreach (var group in apiDescriptionsByPath)
            {
                paths.Add($"/{group.Key}",
                    new OpenApiPathItem
                    {
                        Operations = GenerateOperations(group, schemaRepository)
                    });
            };

            return paths;
        }

        private IDictionary<OperationType, OpenApiOperation> GenerateOperations(
            IEnumerable<ApiDescription> apiDescriptions,
            SchemaRepository schemaRepository)
        {
            var apiDescriptionsByMethod = apiDescriptions
                .OrderBy(_options.SortKeySelector)
                .GroupBy(apiDesc => apiDesc.HttpMethod);

            var operations = new Dictionary<OperationType, OpenApiOperation>();

            foreach (var group in apiDescriptionsByMethod)
            {
                var httpMethod = group.Key;

                if (httpMethod == null)
                    throw new SwaggerGeneratorException(string.Format(
                        "Ambiguous HTTP method for action - {0}. " +
                        "Actions require an explicit HttpMethod binding for Swagger/OpenAPI 3.0",
                        group.First().ActionDescriptor.DisplayName));

                if (group.Count() > 1 && _options.ConflictingActionsResolver == null)
                    throw new SwaggerGeneratorException(string.Format(
                        "Conflicting method/path combination \"{0} {1}\" for actions - {2}. " +
                        "Actions require a unique method/path combination for Swagger/OpenAPI 3.0. Use ConflictingActionsResolver as a workaround",
                        httpMethod,
                        group.First().RelativePath,
                        string.Join(",", group.Select(apiDesc => apiDesc.ActionDescriptor.DisplayName))));

                var apiDescription = group.Count() > 1 ? _options.ConflictingActionsResolver(group) : group.Single();

                operations.Add(OperationTypeMap[httpMethod.ToUpper()], GenerateOperation(apiDescription, schemaRepository));
            };

            return operations;
        }

        private OpenApiOperation GenerateOperation(ApiDescription apiDescription, SchemaRepository schemaRepository)
        {
            OpenApiOperation operation = GenerateOpenApiOperationFromMetadata(apiDescription, schemaRepository);

            try
            {
                operation ??= new OpenApiOperation
                {
                    Tags = GenerateOperationTags(apiDescription),
                    OperationId = _options.OperationIdSelector(apiDescription),
                    Parameters = GenerateParameters(apiDescription, schemaRepository),
                    RequestBody = GenerateRequestBody(apiDescription, schemaRepository),
                    Responses = GenerateResponses(apiDescription, schemaRepository),
                    Deprecated = apiDescription.CustomAttributes().OfType<ObsoleteAttribute>().Any(),
                    Summary = GenerateSummary(apiDescription),
                    Description = GenerateDescription(apiDescription),
                };

                apiDescription.TryGetMethodInfo(out MethodInfo methodInfo);
                var filterContext = new OperationFilterContext(apiDescription, _schemaGenerator, schemaRepository, methodInfo);
                foreach (var filter in _options.OperationFilters)
                {
                    filter.Apply(operation, filterContext);
                }

                return operation;
            }
            catch (Exception ex)
            {
                throw new SwaggerGeneratorException(
                    message: $"Failed to generate Operation for action - {apiDescription.ActionDescriptor.DisplayName}. See inner exception",
                    innerException: ex);
            }
        }

        private string GenerateSummary(ApiDescription apiDescription)
        {
            string operationSummary = apiDescription
                .ActionDescriptor
                ?.EndpointMetadata
                ?.OfType<IEndpointSummaryMetadata>()
                .Select(s => s.Summary)
                .LastOrDefault();

            return operationSummary;
        }

        private string GenerateDescription(ApiDescription apiDescription)
        {
            string operationDescription = apiDescription
                .ActionDescriptor
                ?.EndpointMetadata
                ?.OfType<IEndpointDescriptionMetadata>()
                .Select(s => s.Description)
                .LastOrDefault();

            return operationDescription;
        }

        private OpenApiOperation GenerateOpenApiOperationFromMetadata(ApiDescription apiDescription, SchemaRepository schemaRepository)
        {
            var metadata = apiDescription.ActionDescriptor?.EndpointMetadata;
            var operation = metadata?.OfType<OpenApiOperation>().SingleOrDefault();

            if (operation is null)
            {
                return null;
            }

            // Schemas will be generated via DotSwashbuckle by default.
            foreach (var parameter in operation.Parameters)
            {
                var apiParameter = apiDescription.ParameterDescriptions.SingleOrDefault(desc => desc.Name == parameter.Name && !desc.IsFromBody() && !desc.IsFromForm() && !desc.IsIllegalHeaderParameter());
                if (apiParameter is not null)
                {
                    var propInfo = apiParameter.PropertyInfo();
                    var paramInfo = apiParameter.ParameterInfo();

                    parameter.Schema = GenerateSchema(
                        apiParameter.Type,
                        schemaRepository,
                        propInfo,
                        paramInfo,
                        apiParameter.RouteInfo);

                    var filterContext = new ParameterFilterContext(
                        apiParameter,
                        _schemaGenerator,
                        schemaRepository,
                        propInfo,
                        paramInfo);

                    foreach (var filter in _options.ParameterFilters)
                    {
                        filter.Apply(parameter, filterContext);
                    }
                }
            }

            var requestContentTypes = operation.RequestBody?.Content?.Values;
            if (requestContentTypes is not null)
            {
                foreach (var content in requestContentTypes)
                {
                    RequestBodyFilterContext filterContext = null;
                    var fromBodyParam = apiDescription.ParameterDescriptions.SingleOrDefault(desc => desc.IsFromBody());
                    if (fromBodyParam is not null)
                    {
                        content.Schema = GenerateSchema(
                            fromBodyParam.Type,
                            schemaRepository,
                            fromBodyParam.PropertyInfo(),
                            fromBodyParam.ParameterInfo()
                        );

                        filterContext = new RequestBodyFilterContext(
                            bodyParameterDescription: fromBodyParam,
                            formParameterDescriptions: null,
                            schemaGenerator: _schemaGenerator,
                            schemaRepository: schemaRepository
                        );
                    }
                    else
                    {
                        var fromFormParam = apiDescription.ParameterDescriptions.Where(desc => desc.IsFromForm());

                        if (fromFormParam.Any())
                        {
                            content.Schema = GenerateSchemaFromFormParameters(
                                fromFormParam,
                                schemaRepository
                            );
                            content.Encoding = content.Schema.Properties.ToDictionary(
                                entry => entry.Key,
                                entry => new OpenApiEncoding { Style = ParameterStyle.Form }
                            );
                            filterContext = new RequestBodyFilterContext(
                                bodyParameterDescription: null,
                                formParameterDescriptions: fromFormParam,
                                schemaGenerator: _schemaGenerator,
                                schemaRepository: schemaRepository);
                        }
                    }

                    if (filterContext != null)
                    {
                        foreach (var filter in _options.RequestBodyFilters)
                        {
                            filter.Apply(operation.RequestBody, filterContext);
                        }
                    }
                }
            }

            foreach (var kvp in operation.Responses)
            {
                var response = kvp.Value;
                var responseModel = apiDescription.SupportedResponseTypes.SingleOrDefault(desc => desc.StatusCode.ToString() == kvp.Key);
                if (responseModel is not null)
                {
                    var responseContentTypes = response?.Content?.Values;
                    if (responseContentTypes is not null)
                    {
                        foreach (var content in responseContentTypes)
                        {
                            content.Schema = GenerateSchema(responseModel.Type, schemaRepository);
                        }
                    }
                }
            }

            return operation;
        }

        private IList<OpenApiTag> GenerateOperationTags(ApiDescription apiDescription)
        {
            return _options.TagsSelector(apiDescription)
                .Select(tagName => new OpenApiTag { Name = tagName })
                .ToList();
        }

        private IList<OpenApiParameter> GenerateParameters(ApiDescription apiDescription, SchemaRepository schemaRespository)
        {
            var applicableApiParameters = apiDescription.ParameterDescriptions
                .Where(apiParam =>
                {
                    return !apiParam.IsFromBody() && !apiParam.IsFromForm()
                        && !apiParam.CustomAttributes().OfType<BindNeverAttribute>().Any()
                        && (apiParam.ModelMetadata == null || apiParam.ModelMetadata.IsBindingAllowed)
                        && !apiParam.IsIllegalHeaderParameter(); ;
                });

            return applicableApiParameters
                .Select(apiParam => GenerateParameter(apiParam, schemaRespository))
                .ToList();
        }

        private OpenApiParameter GenerateParameter(
            ApiParameterDescription apiParameter,
            SchemaRepository schemaRepository)
        {
            var name = _options.DescribeAllParametersInCamelCase
                ? apiParameter.Name.ToCamelCase()
                : apiParameter.Name;

            var location = apiParameter.Source != null && ParameterLocationMap.TryGetValue(apiParameter.Source, out var value)
                ? value
                : ParameterLocation.Query;

            var isRequired = apiParameter.IsRequiredParameter();

            var propInfo = apiParameter.PropertyInfo();
            var paramInfo = apiParameter.ParameterInfo();

            Type type;
            if (paramInfo != null && paramInfo.ParameterType == apiParameter.Type)
            {
                type = apiParameter.Type;
            }
            else
            {
                type = apiParameter.ModelMetadata?.ModelType ?? apiParameter.Type;
            }

            var schema = type != null ? GenerateSchema(
                type,
                schemaRepository,
                propInfo,
                paramInfo,
                apiParameter.RouteInfo
            ) : new OpenApiSchema() { Type = "string" };

            var parameter = new OpenApiParameter
            {
                Name = name,
                In = location,
                Required = isRequired,
                Schema = schema
            };

            var filterContext = new ParameterFilterContext(
                apiParameter,
                _schemaGenerator,
                schemaRepository,
                propInfo,
                paramInfo
            );

            foreach (var filter in _options.ParameterFilters)
            {
                filter.Apply(parameter, filterContext);
            }

            return parameter;
        }

        private OpenApiSchema GenerateSchema(
            Type type,
            SchemaRepository schemaRepository,
            PropertyInfo propertyInfo = null,
            ParameterInfo parameterInfo = null,
            ApiParameterRouteInfo routeInfo = null)
        {
            try
            {
                return _schemaGenerator.GenerateSchema(type, schemaRepository, propertyInfo, parameterInfo, routeInfo);
            }
            catch (Exception ex)
            {
                throw new SwaggerGeneratorException(
                    message: $"Failed to generate schema for type - {type}. See inner exception",
                    innerException: ex);
            }
        }

        private OpenApiRequestBody GenerateRequestBody(
            ApiDescription apiDescription,
            SchemaRepository schemaRepository)
        {
            OpenApiRequestBody requestBody = null;
            RequestBodyFilterContext filterContext = null;

            var bodyParameter = apiDescription.ParameterDescriptions
                .FirstOrDefault(paramDesc => paramDesc.IsFromBody());

            var formParameters = apiDescription.ParameterDescriptions
                .Where(paramDesc => paramDesc.IsFromForm());

            if (bodyParameter != null)
            {
                requestBody = GenerateRequestBodyFromBodyParameter(apiDescription, schemaRepository, bodyParameter);

                filterContext = new RequestBodyFilterContext(
                    bodyParameterDescription: bodyParameter,
                    formParameterDescriptions: null,
                    schemaGenerator: _schemaGenerator,
                    schemaRepository: schemaRepository);
            }
            else if (formParameters.Any())
            {
                requestBody = GenerateRequestBodyFromFormParameters(apiDescription, schemaRepository, formParameters);

                filterContext = new RequestBodyFilterContext(
                    bodyParameterDescription: null,
                    formParameterDescriptions: formParameters,
                    schemaGenerator: _schemaGenerator,
                    schemaRepository: schemaRepository);
            }

            if (requestBody != null)
            {
                foreach (var filter in _options.RequestBodyFilters)
                {
                    filter.Apply(requestBody, filterContext);
                }
            }

            return requestBody;
        }

        private OpenApiRequestBody GenerateRequestBodyFromBodyParameter(
            ApiDescription apiDescription,
            SchemaRepository schemaRepository,
            ApiParameterDescription bodyParameter)
        {
            var contentTypes = InferRequestContentTypes(apiDescription);

            var isRequired = bodyParameter.IsRequiredParameter();

            var type = bodyParameter.ModelMetadata?.ModelType ?? bodyParameter.Type;
            var schema = type != null ? GenerateSchema(
                type,
                schemaRepository,
                bodyParameter.PropertyInfo(),
                bodyParameter.ParameterInfo()
            ) : new OpenApiSchema() { Type = "string" };

            return new OpenApiRequestBody
            {
                Content = contentTypes
                    .ToDictionary(
                        contentType => contentType,
                        contentType => new OpenApiMediaType
                        {
                            Schema = schema
                        }
                    ),
                Required = isRequired
            };
        }

        private IEnumerable<string> InferRequestContentTypes(ApiDescription apiDescription)
        {
            // If there's content types explicitly specified via ConsumesAttribute, use them
            var explicitContentTypes = apiDescription.CustomAttributes().OfType<ConsumesAttribute>()
                .SelectMany(attr => attr.ContentTypes)
                .Distinct();
            if (explicitContentTypes.Any()) return explicitContentTypes;

            // If there's content types surfaced by ApiExplorer, use them
            return apiDescription.SupportedRequestFormats
                .Select(format => format.MediaType)
                .Where(x => x != null)
                .Distinct();
        }

        private OpenApiRequestBody GenerateRequestBodyFromFormParameters(
            ApiDescription apiDescription,
            SchemaRepository schemaRepository,
            IEnumerable<ApiParameterDescription> formParameters)
        {
            var contentTypes = InferRequestContentTypes(apiDescription);
            contentTypes = contentTypes.Any() ? contentTypes : new[] { "multipart/form-data", "application/x-www-form-urlencoded" };

            var schema = GenerateSchemaFromFormParameters(formParameters, schemaRepository);

            return new OpenApiRequestBody
            {
                Content = contentTypes
                    .ToDictionary(
                        contentType => contentType,
                        contentType => new OpenApiMediaType
                        {
                            Schema = schema,
                            Encoding = schema.Properties.ToDictionary(
                                entry => entry.Key,
                                entry => new OpenApiEncoding { Style = ParameterStyle.Form }
                            )
                        }
                    )
            };
        }

        private OpenApiSchema GenerateSchemaFromFormParameters(
            IEnumerable<ApiParameterDescription> formParameters,
            SchemaRepository schemaRepository)
        {
            var properties = new Dictionary<string, OpenApiSchema>(StringComparer.Ordinal);
            var requiredPropertyNames = new List<string>();

            foreach (var formParameter in formParameters)
            {
                var name = _options.DescribeAllParametersInCamelCase
                    ? formParameter.Name.ToCamelCase()
                    : formParameter.Name;

                var type = formParameter.ModelMetadata?.ModelType ?? formParameter.Type;
                var schema = type != null ? GenerateSchema(
                    type,
                    schemaRepository,
                    formParameter.PropertyInfo(),
                    formParameter.ParameterInfo()
                ) : new OpenApiSchema() { Type = "string" };

                properties.Add(name, schema);

                if (formParameter.IsRequiredParameter())
                    requiredPropertyNames.Add(name);
            }

            return new OpenApiSchema
            {
                Type = "object",
                Properties = properties,
                Required = new SortedSet<string>(requiredPropertyNames)
            };
        }

        private IList<ApiResponseType> GetResponseTypes(
            ApiDescription apiDescription
        )
        {
            var supportedResponseTypes = new List<ApiResponseType>(apiDescription.SupportedResponseTypes);

            if (apiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                var returnType = UnwrapTask(controllerActionDescriptor.MethodInfo.ReturnType);

                if (typeof(IEndpointMetadataProvider).IsAssignableFrom(returnType))
                {
                    var populateMetadataMethod = returnType.GetMethod("Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider.PopulateMetadata", BindingFlags.Static | BindingFlags.NonPublic);

                    if (populateMetadataMethod != null)
                    {
                        var endpointBuilder = new MetadataEndpointBuilder();
                        populateMetadataMethod.Invoke(null, [controllerActionDescriptor.MethodInfo, endpointBuilder]);

                        var responseTypes = endpointBuilder.Metadata.Cast<IProducesResponseTypeMetadata>().ToList();

                        foreach (var responseType in responseTypes)
                        {
                            supportedResponseTypes.Add(
                                new ApiResponseType()
                                {
                                    IsDefaultResponse = false,
                                    Type = responseType.Type,
                                    StatusCode = responseType.StatusCode,
                                    ApiResponseFormats = responseType.ContentTypes.Select(contentType => new ApiResponseFormat { MediaType = contentType }).ToList()
                                });
                        }
                    }
                }

            }

            return supportedResponseTypes;
        }

        private OpenApiResponses GenerateResponses(
            ApiDescription apiDescription,
            SchemaRepository schemaRepository)
        {
            var supportedResponseTypes = GetResponseTypes(apiDescription)
                .DefaultIfEmpty(new ApiResponseType { StatusCode = 200 });

            var responses = new OpenApiResponses();
            foreach (var responseType in supportedResponseTypes)
            {
                var statusCode = responseType.IsDefaultResponse() ? "default" : responseType.StatusCode.ToString();
                responses.Add(statusCode, GenerateResponse(apiDescription, schemaRepository, statusCode, responseType));
            }
            return responses;
        }

        private OpenApiResponse GenerateResponse(
            ApiDescription apiDescription,
            SchemaRepository schemaRepository,
            string statusCode,
            ApiResponseType apiResponseType)
        {
            var description = ResponseDescriptionMap
                .FirstOrDefault((entry) => Regex.IsMatch(statusCode, entry.Key))
                .Value;

            var responseContentTypes = InferResponseContentTypes(apiDescription, apiResponseType);

            return new OpenApiResponse
            {
                Description = description,
                Content = responseContentTypes.ToDictionary(
                    contentType => contentType,
                    contentType => CreateResponseMediaType(apiResponseType.Type, schemaRepository)
                )
            };
        }

        private IEnumerable<string> InferResponseContentTypes(ApiDescription apiDescription, ApiResponseType apiResponseType)
        {
            // If there's no associated model, return an empty list (i.e. no content)
            if (apiResponseType.Type == null || apiResponseType.Type == typeof(void)) return Enumerable.Empty<string>();

            // If there's content types explicitly specified via ProducesAttribute, use them
            var explicitContentTypes = apiDescription.CustomAttributes().OfType<ProducesAttribute>()
                .SelectMany(attr => attr.ContentTypes)
                .Distinct();
            if (explicitContentTypes.Any()) return explicitContentTypes;

            // If there's content types surfaced by ApiExplorer, use them
            var apiExplorerContentTypes = apiResponseType.ApiResponseFormats
                .Select(responseFormat => responseFormat.MediaType)
                .Distinct();
            if (apiExplorerContentTypes.Any()) return apiExplorerContentTypes;

            return Enumerable.Empty<string>();
        }

        private OpenApiMediaType CreateResponseMediaType(Type type, SchemaRepository schemaRespository)
        {
            return new OpenApiMediaType
            {
                Schema = GenerateSchema(type, schemaRespository)
            };
        }

        private static readonly Dictionary<string, OperationType> OperationTypeMap = new Dictionary<string, OperationType>(StringComparer.Ordinal)
        {
            { "GET", OperationType.Get },
            { "PUT", OperationType.Put },
            { "POST", OperationType.Post },
            { "DELETE", OperationType.Delete },
            { "OPTIONS", OperationType.Options },
            { "HEAD", OperationType.Head },
            { "PATCH", OperationType.Patch },
            { "TRACE", OperationType.Trace }
        };

        private static readonly Dictionary<BindingSource, ParameterLocation> ParameterLocationMap = new Dictionary<BindingSource, ParameterLocation>
        {
            { BindingSource.Query, ParameterLocation.Query },
            { BindingSource.Header, ParameterLocation.Header },
            { BindingSource.Path, ParameterLocation.Path }
        };

        private static readonly IReadOnlyCollection<KeyValuePair<string, string>> ResponseDescriptionMap = new[]
        {
           new KeyValuePair<string, string>("1\\d{2}", "Information"),

            new KeyValuePair<string, string>("201", "Created"),
            new KeyValuePair<string, string>("202", "Accepted"),
            new KeyValuePair<string, string>("204", "No Content"),
            new KeyValuePair<string, string>("2\\d{2}", "Success"),

            new KeyValuePair<string, string>("304", "Not Modified"),
            new KeyValuePair<string, string>("3\\d{2}", "Redirect"),

            new KeyValuePair<string, string>("400", "Bad Request"),
            new KeyValuePair<string, string>("401", "Unauthorized"),
            new KeyValuePair<string, string>("403", "Forbidden"),
            new KeyValuePair<string, string>("404", "Not Found"),
            new KeyValuePair<string, string>("405", "Method Not Allowed"),
            new KeyValuePair<string, string>("406", "Not Acceptable"),
            new KeyValuePair<string, string>("408", "Request Timeout"),
            new KeyValuePair<string, string>("409", "Conflict"),
            new KeyValuePair<string, string>("429", "Too Many Requests"),
            new KeyValuePair<string, string>("4\\d{2}", "Client Error"),

            new KeyValuePair<string, string>("501", "Not Implemented"),
            new KeyValuePair<string, string>("502", "Bad Gateway"),
            new KeyValuePair<string, string>("503", "Service Unavailable"),
            new KeyValuePair<string, string>("504", "Gateway Timeout"),
            new KeyValuePair<string, string>("5\\d{2}", "Server Error"),
            new KeyValuePair<string, string>("default", "Error")
        };

        private static Type UnwrapTask(Type type)
            => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>)
                ? type.GetGenericArguments()[0]
                : type;

        private sealed class MetadataEndpointBuilder : EndpointBuilder
        {
            public override Endpoint Build() => null!;
        }
    }
}
