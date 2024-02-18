using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    /// works used in national agriculture soap dummys
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum AgricultureWorks : int
    {
        Undefined = 0,
        NewConstruction = 1 << 0,
        Expansion = 1 << 1,
        BasicRepair = 1 << 2,
    }
}
