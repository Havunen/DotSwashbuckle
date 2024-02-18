using Newtonsoft.Json;

namespace Dummy.DummyModels.DumbsC
{
    public class qweactualsoap
    {
        [JsonProperty(PropertyName = "dummy")]
        public string dummy { get; set; }

        [JsonProperty(PropertyName = "Cat")]
        public string Cat { get; set; } = "KEKW";

        [JsonProperty(PropertyName = "validationMode")]
        public string ValidationMode { get; set; } = "dynamic";

        [JsonProperty(PropertyName = "EDummySdkVersion")]
        public string EDummySdkVersion { get; set; } = "EDummy-sdk-1.7";
    }
}
