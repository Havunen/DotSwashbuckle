using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class OrderByItem
    {
        public string Field { get; set; }
        public OrderDirection Direction { get; set; } = OrderDirection.Ascending;
    }
}
