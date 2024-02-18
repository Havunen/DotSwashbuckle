using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    /// <summary>
    /// SectionValidation
    /// </summary>
    [Dumb2]
    public class SectionValidation
    {
        public CombinedSection Section { get; set; }
        public GetStats GetStats { get; set; }
    }
}
