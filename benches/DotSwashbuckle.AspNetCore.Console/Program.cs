namespace DotSwashbuckle.AspNetCore.Console;

public class Program
{
    public static void Main(string[] args)
    {
        var benchFile = new OpenApiGenerateJsonBenchmark();
        benchFile.GlobalSetup();

        for (var i = 0; i < 100; i++)
        {
            benchFile.DotSwashbuckleOpenApiV2();
        }
    }
}
