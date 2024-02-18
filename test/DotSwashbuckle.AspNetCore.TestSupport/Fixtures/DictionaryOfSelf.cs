using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.TestSupport
{
    public class DictionaryOfSelf : Dictionary<string, DictionaryOfSelf>
    {
    }
}