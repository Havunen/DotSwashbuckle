using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    ///     State of the createing decision
    /// </summary>
    [Enumsoap]
    public enum createingDecisionState
    {
        Draft = 0,
        Sending = 1,
        Sent = 2,
        Error = 3
    }
}
