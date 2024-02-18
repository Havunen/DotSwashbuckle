using System;
using Dummy.Attributes;

namespace Dummy.Dummies.Dummies4
{
    [EDummyEnum]
    [Flags]
    public enum dummypctmdumType
    {
        Unknown = 0,
        SmlandValue = 1,
        National = 2,
        Slime = 4,
    }
}
