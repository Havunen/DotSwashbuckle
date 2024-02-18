using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    [Enumsoap]
    [Flags]
    public enum GetStats : int
    {
        Pristine = 0,
        Invalid = 1 << 0,
        Valid = 1 << 1,
        // reDFonly
        Forbidden = 1 << 2
    }
}
