using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    internal class ListStringExample : IExamplesProvider<IEnumerable<string>>
    {
        public IEnumerable<string> GetExamples()
        {
            return new[] { "Hello", "there" };
        }
    }
}
