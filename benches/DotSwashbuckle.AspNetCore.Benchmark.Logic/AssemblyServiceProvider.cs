using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using DotSwashbuckle.AspNetCore.Cli;

namespace DotSwashbuckle.AspNetCore.Benchmark.Logic
{
    public class AssemblyServiceProvider
    {
        public static IServiceProvider GetServiceProvider(Assembly startupAssembly)
        {
            if (TryGetCustomHost(startupAssembly, "SwaggerHostFactory", "CreateHost", out IHost host))
            {
                return host.Services;
            }

            if (TryGetCustomHost(startupAssembly, "SwaggerWebHostFactory", "CreateWebHost", out IWebHost webHost))
            {
                return webHost.Services;
            }

            try
            {
                return WebHost.CreateDefaultBuilder()
                   .UseStartup(startupAssembly.GetName().Name)
                   .Build()
                   .Services;
            }
            catch
            {
                var serviceProvider = HostingApplication.GetServiceProvider(startupAssembly);

                if (serviceProvider != null)
                {
                    return serviceProvider;
                }

                throw;
            }
        }

        private static bool TryGetCustomHost<THost>(
            Assembly startupAssembly,
            string factoryClassName,
            string factoryMethodName,
            out THost host)
        {
            // Scan the assembly for any types that match the provided naming convention
            var factoryTypes = startupAssembly.DefinedTypes
                .Where(t => t.Name == factoryClassName)
                .ToList();

            if (!factoryTypes.Any())
            {
                host = default;
                return false;
            }

            if (factoryTypes.Count() > 1)
                throw new InvalidOperationException($"Multiple {factoryClassName} classes detected");

            var factoryMethod = factoryTypes
                .Single()
                .GetMethod(factoryMethodName, BindingFlags.Public | BindingFlags.Static);

            if (factoryMethod == null || factoryMethod.ReturnType != typeof(THost))
                throw new InvalidOperationException(
                    $"{factoryClassName} class detected but does not contain a public static method " +
                    $"called {factoryMethodName} with return type {typeof(THost).Name}");

            host = (THost)factoryMethod.Invoke(null, null);
            return true;
        }
    }
}
