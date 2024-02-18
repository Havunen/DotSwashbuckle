using Dummy.Attributes;
using System;

namespace Dummy.Dummies
{
    /// <summary>
    /// Goes 2009/81/EC (Defence soaps)
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum CatType : int
    {
        /// <summary>
        ///     Default value, error state.
        /// </summary>
        Undefined = 0,
        /// <summary>
        ///     Any official Slime Cat.
        /// </summary>
        AnyOfficialSlime = 1 << 0,
        /// <summary>
        ///     Any official Slime Cat.
        /// </summary>
        SelecqweSlime = 1 << 1
    }
}
