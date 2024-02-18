using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    public class DictionaryRequestExample : IExamplesProvider<Dictionary<string, object>>
    {
        public Dictionary<string, object> GetExamples()
        {
            return new Dictionary<string, object>()
            {
                {"PropertyInt", 1},
                {"PropertyString", "Some string"}
            };
        }
    }
}
