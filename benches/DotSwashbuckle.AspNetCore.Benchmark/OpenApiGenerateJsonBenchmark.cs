using BenchmarkDotNet.Attributes;
using DotSwashbuckle.AspNetCore.Benchmark.Logic;
using System.Runtime.Loader;

namespace DotSwashbuckle.AspNetCore.Benchmark
{
    public class OpenApiGenerateJsonBenchmark
    {
        private readonly Dictionary<string, IServiceProvider> assemblyProviders = new(StringComparer.Ordinal);

        private string[] assemblies = new string[] { "Basic.dll" };

        [GlobalSetup]
        public void GlobalSetup()
        {
            assemblyProviders.Add(
                "Basic.dll",
                AssemblyServiceProvider.GetServiceProvider(
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(
                        Path.Combine(Directory.GetCurrentDirectory(), "Basic.dll")
                    )
                )
            );
        }

        [Benchmark]
        public async Task<string> DotSwashbuckleOpenApiV2()
        {
            return await DotSwashbuckleGenerator.CreateSwaggerDoc(
                assemblyProviders["Basic.dll"],
                false,
                true
            );
        }
    }
}
