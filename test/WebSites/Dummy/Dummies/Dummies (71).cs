using Dummy.Attributes;

namespace Dummy.Dummies
{
    [Enumsoap]
    public enum ValidationRuleType
    {
        Undefined = 0,
        Equals = 1,
        MinValue = 2,
        MaxValue = 3,
        MaxLength = 4,
        MaxDecimals = 5,
        MinAnswerCount = 6,
        MaxAnswerCount = 7,
    }
}
