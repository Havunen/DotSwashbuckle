using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    /// <summary>
    /// Wraps ItemObject choice regarding coupon invitation.
    /// </summary>
    [Dumb2]
    public class InviteHandlingsoap
    {
        /// <summary>
        /// The ItemObject choice
        /// </summary>
        public InviteReply Action { get; set; }
    }
}
