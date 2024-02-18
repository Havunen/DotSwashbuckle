using System;

namespace DotSwashbuckle.AspNetCore.TestSupport
{
    public class TypeWithObsoleteAttribute
    {
        [Obsolete]
        public string ObsoleteProperty { get; set; }
    }
}