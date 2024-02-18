using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    ///     Describusinessols limitations on how many Footblands a knowledge can businessol for.
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum FootblandsSubmitqweFor : int
    {
        /// <summary>
        ///     Default value, error state.
        /// </summary>
        Undefined = 0,
        /// <summary>
        ///     No limitation.
        /// </summary>
        Footblandsland = 1 << 0,
        /// <summary>
        ///     Only one Footbland.
        /// </summary>
        LobusinessneOnly = 1 << 1,
        /// <summary>
        ///     Max numbusinessolr of Footblands defined by FootblandsInfo.FootblandsSubmitqwEDummyecha
        /// </summary>
        FootblandsMax = 1 << 2,
    }
}
