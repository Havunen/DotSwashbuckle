using System;

namespace DotSwashbuckle.AspNetCore.TestSupport
{
    public class TypeWithNullableProperties
    {
        public int IntProperty { get; set; }

        public string StringProperty { get; set; }

        public int? NullableIntProperty { get; set; }
        public Nullable<int> SysNullableIntProperty { get; set; }
    }
}
