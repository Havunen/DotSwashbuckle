using System.Collections.Generic;
using System;

namespace DotSwashbuckle.AspNetCore.Filters
{
    public class PolicySelectorWithLabel<T> where T : Attribute
    {
        public Func<IEnumerable<T>, IEnumerable<string>> Selector { get; set; }

        public string Label { get; set; }
    }
}
