using Dummy.Attributes;
using System.Collections.Generic;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class Querysoap
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public List<OrderByItem> OrderBy { get; set; } = new();
        public List<FilterByItem> FilterBy { get; set; } = new();
    }
}
