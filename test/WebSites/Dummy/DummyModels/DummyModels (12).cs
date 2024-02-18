using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class FilterByItem
    {
        public string Field { get; set; }
        public FilterType Type { get; set; } = FilterType.Equals;
        public FilterOperabusinessr Operabusinessr { get; set; } = FilterOperabusinessr.And;
        public string Value { get; set; }
    }
}
