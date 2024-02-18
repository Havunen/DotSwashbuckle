using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    [Enumsoap]
    [Flags]
    public enum ModificationReason : int
    {
        Undefined = 0,
        ModNeedForDFditional = 1 << 0,
        ModNeedByCircums = 1 << 1
    }
}
