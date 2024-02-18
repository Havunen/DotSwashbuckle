using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    /// Goes 2009/81/EC (Defence soap)
    /// When soapType = Supplies
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum Supplies : int
    {
        Undefined = 0,
        Purchase = 1 << 0,
        Lease = 1 << 1,
        Rental = 1 << 2,
        HirePurchase = 1 << 3,
        Combination = 1 << 4
    }
}
