using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.ApiDescriptions;
using Microsoft.OpenApi.Readers;
using DotSwashbuckle.AspNetCore.Swagger;
using Snapshooter;
using Snapshooter.Xunit;
using Xunit;

namespace DotSwashbuckle.AspNetCore.IntegrationTests
{
    public class DocumentProviderTests
    {
        [Theory]
        [InlineData(typeof(Basic.Startup), new[] { "v1" })]
        [InlineData(typeof(CustomUIConfig.Startup), new[] { "v1" })]
        [InlineData(typeof(CustomUIIndex.Startup), new[] { "v1" })]
        [InlineData(typeof(GenericControllers.Startup), new[] { "v1" })]
        [InlineData(typeof(MultipleVersions.Startup), new[] { "1.0", "2.0" })]
        [InlineData(typeof(OAuth2Integration.Startup), new[] { "v1" })]
        [InlineData(typeof(Dummy.Startup), new[] { "v1", "doc-v1", "doc-v2", "doc-v3", "doc-v4", "doc-v5", "doc-v6", "doc-v7", "doc-v8", "doc-v9" })]
        public void DocumentProvider_ExposesAllDocumentNames(Type startupType, string[] expectedNames)
        {
            var testSite = new TestSite(startupType);
            var server = testSite.BuildServer();
            var services = server.Host.Services;
            var documentProvider = (IDocumentProvider)services.GetService(typeof(IDocumentProvider));

            var documentNames = documentProvider.GetDocumentNames();

            Assert.Equal(expectedNames, documentNames);
        }

        [Theory]
        [InlineData(typeof(Basic.Startup), "v1")]
        // Dummy could be added here once all the tests are passing
        //[InlineData(typeof(Dummy.Startup), "v1")]
        //[InlineData(typeof(Dummy.Startup), "doc-v1")]
        //[InlineData(typeof(Dummy.Startup), "doc-v2")]
        //[InlineData(typeof(Dummy.Startup), "doc-v3")]
        //[InlineData(typeof(Dummy.Startup), "doc-v4")]
        //[InlineData(typeof(Dummy.Startup), "doc-v5")]
        //[InlineData(typeof(Dummy.Startup), "doc-v6")]
        //[InlineData(typeof(Dummy.Startup), "doc-v7")]
        //[InlineData(typeof(Dummy.Startup), "doc-v8")]
        //[InlineData(typeof(Dummy.Startup), "doc-v9")]
        [InlineData(typeof(CustomUIConfig.Startup), "v1")]
        [InlineData(typeof(CustomUIIndex.Startup), "v1")]
        [InlineData(typeof(GenericControllers.Startup), "v1")]
        [InlineData(typeof(MultipleVersions.Startup), "2.0")]
        [InlineData(typeof(OAuth2Integration.Startup), "v1")]
        public async Task DocumentProvider_ExposesGeneratedSwagger(Type startupType, string documentName)
        {
            var testSite = new TestSite(startupType);
            var server = testSite.BuildServer();
            var services = server.Host.Services;

            var documentProvider = (IDocumentProvider)services.GetService(typeof(IDocumentProvider));
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8, bufferSize: 2048, leaveOpen: true))
                {
                    await documentProvider.GenerateAsync(documentName, writer);
                    await writer.FlushAsync();
                }

                stream.Position = 0L;
                new OpenApiStreamReader().Read(stream, out var diagnostic);
                Assert.NotNull(diagnostic);
                Assert.Empty(diagnostic.Errors);
            }
        }


        [Theory]
        [InlineData(typeof(Basic.Startup), "v1")]
        // Dummy could be added here once all the tests are passing
        [InlineData(typeof(Dummy.Startup), "v1")]
        [InlineData(typeof(Dummy.Startup), "doc-v1")]
        [InlineData(typeof(Dummy.Startup), "doc-v2")]
        [InlineData(typeof(Dummy.Startup), "doc-v3")]
        [InlineData(typeof(Dummy.Startup), "doc-v4")]
        [InlineData(typeof(Dummy.Startup), "doc-v5")]
        [InlineData(typeof(Dummy.Startup), "doc-v6")]
        [InlineData(typeof(Dummy.Startup), "doc-v7")]
        [InlineData(typeof(Dummy.Startup), "doc-v8")]
        [InlineData(typeof(Dummy.Startup), "doc-v9")]
        [InlineData(typeof(CustomUIConfig.Startup), "v1")]
        [InlineData(typeof(CustomUIIndex.Startup), "v1")]
        [InlineData(typeof(GenericControllers.Startup), "v1")]
        [InlineData(typeof(MultipleVersions.Startup), "2.0")]
        [InlineData(typeof(OAuth2Integration.Startup), "v1")]
        public async Task Examples_SwaggerJson_SnapshotMatches(Type startupType, string documentName)
        {
            var testSite = new TestSite(startupType);
            var server = testSite.BuildServer();
            var services = server.Host.Services;

            var documentProvider = (IDocumentProvider)services.GetService(typeof(IDocumentProvider));

            await using var stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            await documentProvider.GenerateAsync(documentName, stringWriter);

			// Get the generated Swagger JSON as a string
			var swaggerJson = stringWriter.ToString();

			// Assert that the generated Swagger JSON matches the snapshot
			Snapshot.Match(swaggerJson, SnapshotNameExtension.Create(startupType.FullName + documentName));
        }

        [Fact]
        public async Task DocumentProvider_ThrowsUnknownDocument_IfUnknownDocumentName()
        {
            var testSite = new TestSite(typeof(Basic.Startup));
            var server = testSite.BuildServer();
            var services = server.Host.Services;

            var documentProvider = (IDocumentProvider)services.GetService(typeof(IDocumentProvider));
            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                await Assert.ThrowsAsync<UnknownSwaggerDocument>(
                    () => documentProvider.GenerateAsync("NotADocument", writer));
            }
        }
    }
}
