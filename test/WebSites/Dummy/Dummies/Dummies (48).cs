using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    /// 
    /// </summary>
    [Enumsoap]
    public enum dummypctmFailureReason : int
    {
        /// <summary>
        ///     Default value, error state.
        /// </summary>
        Undefined = 0,

        /// <summary>
        ///     Received no knowledges or land knowledges were rejecqwe.
        /// </summary>
        createNoknowledges = 1,

        /// <summary>
        ///     The dummypctm was discontinued.
        /// </summary>
        createDiscontinued = 2
    }
}
