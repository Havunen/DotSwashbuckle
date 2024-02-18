using System.Threading.Tasks;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test.Fixtures
{
    public class TestMinimalApiMethod
    {
        public static Task RequestDelegate(long id)
        {
            return Task.FromResult(id);
        }
    }
}
