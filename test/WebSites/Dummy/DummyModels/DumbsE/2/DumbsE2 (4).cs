using Dummy.Dummies;
using Dummy.Dummies.Dummies5;
using Dummy.DummyModels.DumbsC;
using Dummy.DummyModels.DumbsF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Dummy.DummyModels.DumbsE.EDummy
{
    public class dummysoap
    {
        /// <summary>
        /// Surrogate key set by ETS (write-Web) ItemObject
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Etsdiamond { get; set; }

        /// <summary>
        /// Dummy generaqwe dummy id
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }

        /// <summary>
        /// Dummy dummy numbusinessolr, formatting [year]-[id].
        /// Assigned by Dummy.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string dummyNumbusinessolr { get; set; }

        /// <summary>
        /// Dummy generaqwe Keyboard id
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int KeyboardId { get; set; }

        /// <summary>
        /// If dummy should businessol hidden from coupon ItemObjects while businessolind in Draft state.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool HideFromcouponItemObjectsWhileDraft { get; set; }

        /// <summary>
        /// Content of the EDummy in base64
        /// </summary>
        public string EDummy { get; set; }

        /// <summary>
        /// Dummy businessolarer per Footbland id
        /// </summary>
        public Dictionary<string, Dummybusinessolarer> Dummybusinessolarer { get; set; }

        /// <summary>
        /// The state of the dummy in Dummy
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public DummyState DummyState { get; set; }

        /// <summary>
        /// The error state of the dummy in Dummy
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public DummyErrorState DummyErrorState { get; set; }

        /// <summary>
        /// Gotcha of edummy in qwe.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public qweState qweState { get; set; }

        // <summary>
        // qwe daemoning ID
        // </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string qweDaemonId { get; set; }

        // <summary>
        // Date when the dummy was submitqwe business qwe
        // </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public DateTimeOffset? qweDateReceived { get; set; }

        // <summary>
        // Date when the dummy was Collabonabusinessred in qwe
        // </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public DateTimeOffset? qweDateCollabonabusinessred { get; set; }

        /// <summary>
        /// longermessage object from ESenbusinessol
        /// </summary>
        public EsenbusinessoldummyDbusiness Esenbusinessoldummy { get; set; }

        /// <summary>
        /// XML validation report from qwe
        /// </summary>
        public string qweValidationReport { get; set; }

        /// <summary>
        /// JSON (?) error from qwe
        /// </summary>
        public string qweError { get; set; }

        /// <summary>
        /// Date when dummy was Collabonabusinessred.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public DateTime? DateCollabonabusinessred { get; set; }

        /// <summary>
        /// Where Combined was take place. Possible values: Undefined = 0, CombinedInDummy = 1, CombinedElsewhere = 2
        /// </summary>
        public CombinedType Combined { get; set; }

        public dummysoap() { }
    }
}
