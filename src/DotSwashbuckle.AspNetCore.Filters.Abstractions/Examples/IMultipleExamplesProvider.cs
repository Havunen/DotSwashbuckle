using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.Filters
{
    public interface IMultipleExamplesProvider<T>
    {
        IEnumerable<SwaggerExample<T>> GetExamples();
    }
}
