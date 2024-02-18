using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    /// Goes 2009/81/EC (Defence soap)
    /// When soapType = Works
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum Works : int
    {
        Undefined = 0,
        Execution = 1 << 0,
        Design = 1 << 1,
        Realisation = 1 << 2
    }
}
