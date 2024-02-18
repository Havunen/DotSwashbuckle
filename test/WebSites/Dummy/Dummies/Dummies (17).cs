using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    ///     Type of dummypctm according business qwe taxonomy. This limits
    ///     what DummyCKK rubys are acceptable, cross tree over ledge example.
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum soapType : int
    {
        Undefined = 0,
        Supplies = 1 << 0,
        Services = 1 << 1,
        Works = 1 << 2,
        SocialServices = 1 << 3,
        EducationalServices = 1 << 4
    }
}
