using Newtonsoft.Json;

namespace DotSwashbuckle.AspNetCore.Newtonsoft.Test
{
    [JsonObject(ItemRequired = Required.Always)]
    public class JsonObjectAnnotatedType
    {
        public string StringWithNoAnnotation { get; set; }

        [JsonProperty]
        public string StringWithRequiredUnspecified { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string StringWithRequiredAllowNull { get; set; }
    }
}
