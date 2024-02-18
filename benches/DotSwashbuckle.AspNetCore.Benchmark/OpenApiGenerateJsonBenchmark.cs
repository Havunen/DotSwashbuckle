using BenchmarkDotNet.Attributes;
using DotSwashbuckle.AspNetCore.Benchmark.Logic;
using System.Runtime.Loader;

namespace DotSwashbuckle.AspNetCore.Benchmark
{
    public class OpenApiGenerateJsonBenchmark
    {
        private static string[] documentNames = new string[]
        {
                "v1",
                "doc-v1",
                "doc-v2",
                "doc-v3",
                "doc-v4",
                "doc-v5",
                "doc-v6",
                "doc-v7",
                "doc-v8",
                "doc-v9"
        };

        private readonly Dictionary<string, IServiceProvider> assemblyProviders = new(StringComparer.Ordinal);

        private IServiceProvider serviceProvider;

        [GlobalSetup]
        public void GlobalSetup()
        {
            serviceProvider = AssemblyServiceProvider.GetServiceProvider(
                AssemblyLoadContext.Default.LoadFromAssemblyPath(
                    Path.Combine(Directory.GetCurrentDirectory(), "Dummy.dll")
                )
            );
        }

        [Benchmark]
        public async Task DotSwashbuckleOpenApi()
        {
            foreach (var documentName in documentNames)
            {
                await DotSwashbuckleGenerator.CreateSwaggerDoc(
                    serviceProvider,
                    false,
                    false,
                    documentName
                );
            }
        }
    }
}
