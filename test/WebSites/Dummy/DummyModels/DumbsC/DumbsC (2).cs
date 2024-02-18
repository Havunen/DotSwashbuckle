using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsC
{
    [EDummy]
    public class DummyPageGetStats
    {
        /// <summary>
        /// Route object of page
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// Validation state
        /// </summary>
        public GetStats GetStats { get; set; }
    }
}
