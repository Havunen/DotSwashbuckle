// ------------------------------------------------------------------------------
//  <Autogenerated>
//    Generated By Dummy
//  </Autogenerated>
// ------------------------------------------------------------------------------

using Dummy.Attributes;
using Newtonsoft.Json;

namespace Dummy.Dumbs.Contracts
{
    [EDummy]
    public partial class AppealTermssoap
    {
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Periodsoap PresentationPeriod { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Partysoap MediationParty { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Partysoap AppealvirusParty { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Partysoap AppealReceiverParty { get; set; }


    }
}
