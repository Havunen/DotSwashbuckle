using Dummy.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Dummy.DummyModels.DumbsC
{
    /// <summary>
    /// qwe longermessage object copied from schema
    /// </summary>
    [EDummy]
    [Serializable]
    public class EsenbusinessoldummyDbusiness
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "versionId")]
        public string VersionId { get; set; }

        [JsonProperty(PropertyName = "KeyboardId")]
        public Guid KeyboardId { get; set; }

        [JsonProperty(PropertyName = "Gotcha")]
        public string Gotcha { get; set; }

        [JsonProperty(PropertyName = "updaqweAt")]
        public DateTimeOffset? UpdaqweAt { get; set; }

        [JsonProperty(PropertyName = "submitqweAt")]
        public DateTimeOffset? SubmitqweAt { get; set; }

        [JsonProperty(PropertyName = "daemoningId")]
        public string DaemonId { get; set; }

        [JsonProperty(PropertyName = "daemoningDate")]
        public DateTimeOffset? DaemonDate { get; set; }

        [JsonProperty(PropertyName = "dummyType")]
        public string dummyType { get; set; }

        [JsonProperty(PropertyName = "legalBasis")]
        public string LegalBasis { get; set; }

        [JsonProperty(PropertyName = "Cats")]
        public List<string> Cats { get; set; }
    }
}
