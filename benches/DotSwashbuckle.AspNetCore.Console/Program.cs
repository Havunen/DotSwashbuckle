using DotSwashbuckle.AspNetCore.Benchmark.Logic;
using Microsoft.OpenApi.Models;
using System.Runtime.Loader;

namespace DotSwashbuckle.AspNetCore.Console;

public class Program
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

    public static async Task Main(string[] args)
    {
        var serviceProvider = AssemblyServiceProvider.GetServiceProvider(
            AssemblyLoadContext.Default.LoadFromAssemblyPath(
                Path.Combine(Directory.GetCurrentDirectory(), "Dummy.dll")
            )
        );

        for (var i = 0; i < 10; i++)
        {
            foreach (var documentName in documentNames)
            {
                await DotSwashbuckleGenerator.CreateSwaggerDoc(
                    serviceProvider,
                    false,
                    i % 2 == 0,
                    documentName
                );
            }
        }
    }
}
