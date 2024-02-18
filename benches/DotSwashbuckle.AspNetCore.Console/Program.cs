using DotSwashbuckle.AspNetCore.Benchmark.Logic;
using System.Runtime.Loader;

namespace DotSwashbuckle.AspNetCore.Console;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = AssemblyServiceProvider.GetServiceProvider(
            AssemblyLoadContext.Default.LoadFromAssemblyPath(
                Path.Combine(Directory.GetCurrentDirectory(), "Basic.dll")
            )
        );

        for (var i = 0; i < 1000; i++)
        {
            DotSwashbuckleGenerator.CreateSwaggerDoc(
                serviceProvider,
                false,
                true
            );
        }
    }
}
