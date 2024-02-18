using System.Text.Json.Serialization;
using DotSwashbuckle.AspNetCore.TestSupport;

namespace Swashbuckle.AspNetCore.SwaggerGen.Test.SchemaGenerator;

[JsonSerializable(typeof(IntEnum))]
[JsonSerializable(typeof(LongEnum))]
public partial class CustomJsonSerializerContext : JsonSerializerContext
{
}
