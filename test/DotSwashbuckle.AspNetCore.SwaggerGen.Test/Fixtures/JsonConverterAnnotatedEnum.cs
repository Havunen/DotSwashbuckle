using System.Text.Json.Serialization;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JsonConverterAnnotatedEnum
    {
        Value1 = 2,
        Value2 = 4,
        X = 8
    }
}
