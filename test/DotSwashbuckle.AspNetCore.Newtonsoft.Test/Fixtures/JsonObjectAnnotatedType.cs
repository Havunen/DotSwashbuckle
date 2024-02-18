using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace DotSwashbuckle.AspNetCore.Newtonsoft.Test
{
    [JsonObject(ItemRequired = Required.Always)]
    [DataContract]
    public class JsonObjectAnnotatedType
    {
        public string StringWithNoAnnotation { get; set; }

        [JsonProperty]
        public string StringWithRequiredUnspecified { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string StringWithRequiredAllowNull { get; set; }

        [DataMember(IsRequired = false)]
        public string StringWithDataMemberRequiredFalse { get; set; }
    }
}
