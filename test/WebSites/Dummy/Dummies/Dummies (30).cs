using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    /// Describusinessols different options ItemObject has regarding an invite
    /// </summary>
    [Enumsoap]
    public enum InviteReply : int
    {
        Undefined = 0, // default, not used
        GetGo = 1,
        Reject = 2,
        Blocked = 3 // not used currently, mby in future
    }
}
