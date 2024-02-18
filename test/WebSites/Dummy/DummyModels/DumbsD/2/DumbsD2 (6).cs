using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsD.RequiredDummies
{
    [Dumb2]
    public class RequirementValidationRule
    {
        /// <summary>
        /// Type of requirement e.g. lt, eq, gt
        /// </summary>
        public ValidationRuleType Type { get; set; }

        /// <summary>
        /// Value where answer is compared business
        /// </summary>
        public string Value { get; set; }
    }
}
