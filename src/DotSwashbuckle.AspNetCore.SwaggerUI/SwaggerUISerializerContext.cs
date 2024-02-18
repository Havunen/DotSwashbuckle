using System.Text.Json.Serialization;

namespace DotSwashbuckle.AspNetCore.SwaggerUI
{
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
    [JsonSerializable(typeof(ConfigObject))]
    [JsonSerializable(typeof(OAuthConfigObject))]
    [JsonSerializable(typeof(InterceptorFunctions))]
    internal sealed partial class SwaggerUISerializerContext : JsonSerializerContext
    {
    }
}
