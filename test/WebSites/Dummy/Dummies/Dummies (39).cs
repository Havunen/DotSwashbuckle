using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    /// 
    /// </summary>
    [Enumsoap]
    public enum dummyDeliveryMethod : int
    {
        /// <summary>
        ///     Default value, error state.
        /// </summary>
        Undefined = 0,

        /// <summary>
        ///     The dummy was delivered with edummy.
        /// </summary>
        IcarEdummys = 1,

        /// <summary>
        ///     The dummy was delivered with esender.
        /// </summary>
        IcarEsender = 2,

        /// <summary>
        ///     The dummy was delivered by other means specified in Noncreate.OriginaldummySentViaOther.
        /// </summary>
        OtherMeans = 3
    }
}
