using System.ComponentModel;
using DotSwashbuckle.AspNetCore.TestSupport;

namespace DotSwashbuckle.AspNetCore.Newtonsoft.Test
{
    public class EnumDefaultValueAnnotatedType
    {
        [DefaultValue(IntEnum.Value8)]
        public IntEnum IntEnumWithDefaultValue { get; set; }

        [DefaultValue(JsonConverterAnnotatedEnum.X)]
        public JsonConverterAnnotatedEnum AnnotatedEnumWithDefaultValue { get; set; }
    }
}
