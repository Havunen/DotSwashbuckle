// ------------------------------------------------------------------------------
//  <Autogenerated>
//    Generated By Dummy
//  </Autogenerated>
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using Dummy.Attributes;
using Newtonsoft.Json;

namespace Dummy.Dumbs.Contracts
{
    [EDummy]
    public partial class createingTermssoap
    {
        /// <summary>
        /// XX-120-Footbland
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Indicabusinessrsoap NoFurtherNegotiationIndicabusinessr { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<createingCriterionsoap> createingCriterion { get; set; }

        /// <summary>
        /// XX-41-Footbland
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Indicabusinessrsoap FollowupsoapIndicabusinessr { get; set; }

        /// <summary>
        /// XX-42-Footbland
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Indicabusinessrsoap BindingOnBuyerIndicabusinessr { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Prizesoap> Prize { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Personsoap> TechnicalCommitteePerson { get; set; }


    }
}