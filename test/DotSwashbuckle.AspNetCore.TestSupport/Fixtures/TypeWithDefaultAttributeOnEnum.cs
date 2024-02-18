using System.ComponentModel;

namespace DotSwashbuckle.AspNetCore.TestSupport
{
    public class TypeWithDefaultAttributeOnEnum
    {
        [DefaultValue(IntEnum.Value4)]
        public IntEnum EnumWithDefault { get; set; }
    }
}
