using Newtonsoft.Json;

namespace DotSwashbuckle.AspNetCore.Newtonsoft.Test
{
    public class JsonRequiredAnnotatedType
    {
        [JsonRequired]
        public string StringWithJsonRequired { get; set; }
    }
}