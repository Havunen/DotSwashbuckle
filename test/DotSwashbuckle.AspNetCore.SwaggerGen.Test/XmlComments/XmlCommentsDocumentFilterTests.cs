using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Xunit;
using System;
using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    public class XmlCommentsDocumentFilterTests
    {
        [Theory]
        [InlineData(typeof(FakeControllerWithXmlComments))]
        [InlineData(typeof(FakeControllerWithInheritDoc))]
        [InlineData(typeof(FakeControllerWithRecursiveInheritDoc))]
        public void Apply_SetsTagDescription_FromControllerSummaryTags(Type fakeController)
        {
            var options = new SwaggerGeneratorOptions();
            var document = new OpenApiDocument();
            var filterContext = new DocumentFilterContext(
                new[]
                {
                    new ApiDescription
                    {
                        ActionDescriptor = new ControllerActionDescriptor
                        {
                            ControllerTypeInfo = fakeController.GetTypeInfo(),
                            ControllerName = nameof(fakeController)
                        }
                    },
                    new ApiDescription
                    {
                        ActionDescriptor = new ControllerActionDescriptor
                        {
                            ControllerTypeInfo = fakeController.GetTypeInfo(),
                            ControllerName = nameof(fakeController)
                        }
                    }
                },
                null,
                null);

            Subject(options).Apply(document, filterContext);

            Assert.Equal(1, document.Tags.Count);
            Assert.Equal("Summary for FakeControllerWithXmlComments", document.Tags[0].Description);
        }

        [Theory]
        [InlineData(typeof(FakeControllerWithInfiniteLoopInheritDoc))]
        public void Apply_InfiniteLoopOnInheritDoc_StopsAndResultNull(Type fakeController)
        {
            var options = new SwaggerGeneratorOptions();
            var document = new OpenApiDocument();
            var filterContext = new DocumentFilterContext(
                new[]
                {
                    new ApiDescription
                    {
                        ActionDescriptor = new ControllerActionDescriptor
                        {
                            ControllerTypeInfo = fakeController.GetTypeInfo(),
                            ControllerName = nameof(fakeController)
                        }
                    },
                    new ApiDescription
                    {
                        ActionDescriptor = new ControllerActionDescriptor
                        {
                            ControllerTypeInfo = fakeController.GetTypeInfo(),
                            ControllerName = nameof(fakeController)
                        }
                    }
                },
                null,
                null);

            Subject(options).Apply(document, filterContext);

            Assert.Equal(1, document.Tags.Count);
            Assert.Equal("Summary for FakeControllerWithXmlComments", document.Tags[0].Description);
        }

        [Fact]
        public void Uses_Proper_Tag_Name()
        {
            var options = new SwaggerGeneratorOptions();
            var document = new OpenApiDocument();
            var expectedTagName = "AliasControllerWithXmlComments";
            var filterContext = new DocumentFilterContext(
                new[]
                {
                    new ApiDescription
                    {
                        ActionDescriptor = new ControllerActionDescriptor
                        {
                            ControllerTypeInfo = typeof(FakeControllerWithXmlComments).GetTypeInfo(),
                            ControllerName = nameof(FakeControllerWithXmlComments),
                            RouteValues = new Dictionary<string, string> { { "controller", expectedTagName } }
                        }
                    },
                    new ApiDescription
                    {
                        ActionDescriptor = new ControllerActionDescriptor
                        {
                            ControllerTypeInfo = typeof(FakeControllerWithXmlComments).GetTypeInfo(),
                            ControllerName = nameof(FakeControllerWithXmlComments),
                            RouteValues = new Dictionary<string, string> { { "controller", expectedTagName } }
                        }
                    }
                },
                null,
                null);

            Subject(options).Apply(document, filterContext);

            Assert.Equal(1, document.Tags.Count);
            Assert.Equal(expectedTagName, document.Tags[0].Name);
            Assert.Equal("Summary for FakeControllerWithXmlComments", document.Tags[0].Description);
        }
        private XmlCommentsDocumentFilter Subject(SwaggerGeneratorOptions options)
        {
            return new XmlCommentsDocumentFilter(options, SwaggerGenOptionsExtensions.ParseXmlCommentDescriptors($"{typeof(FakeControllerWithXmlComments).Assembly.GetName().Name}.xml"));
        }
    }
}