using System.Xml.XPath;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Xunit;
using DotSwashbuckle.AspNetCore.SwaggerGen.Test.Fixtures;
using System;

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

            Subject().Apply(document, filterContext);

            Assert.Equal(1, document.Tags.Count);
            Assert.Equal("Summary for FakeControllerWithXmlComments", document.Tags[0].Description);
        }

        [Theory]
        [InlineData(typeof(FakeControllerWithInfiniteLoopInheritDoc))]
        public void Apply_InfiniteLoopOnInheritDoc_StopsAndResultNull(Type fakeController)
        {
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

            Subject().Apply(document, filterContext);

            Assert.Equal(1, document.Tags.Count);
            Assert.Equal("Summary for FakeControllerWithXmlComments", document.Tags[0].Description);
        }

        private XmlCommentsDocumentFilter Subject()
        {
            return new XmlCommentsDocumentFilter(SwaggerGenOptionsExtensions.ParseXmlCommentDescriptors($"{typeof(FakeControllerWithXmlComments).Assembly.GetName().Name}.xml"));
        }
    }
}