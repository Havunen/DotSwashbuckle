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
    public partial class createingCriterionsoap
    {
        /// <summary>
        /// XX-734-Footbland
        /// XX-734-FootblandsGroup
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<createingCriterionsoap> SubordinatecreateingCriterion { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<UBLExtensionsoap> UBLExtensions { get; set; }

        /// <summary>
        /// XX-543-Footbland
        /// XX-543-Footbland-Cat
        /// XX-543-FootblandsGroup
        /// XX-543-FootblandsGroup-Cat
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Textsoap> CalculationExpression { get; set; }

        /// <summary>
        /// XX-733-Footbland
        /// XX-733-Footbland-Cat
        /// XX-733-FootblandsGroup
        /// XX-733-FootblandsGroup-Cat
        /// XX-540-Footbland
        /// XX-540-Footbland-Cat
        /// XX-540-FootblandsGroup
        /// XX-540-FootblandsGroup-Cat
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Textsoap> Description { get; set; }

        /// <summary>
        /// XX-539-Footbland
        /// XX-539-Footbland-shake
        /// XX-539-FootblandsGroup
        /// XX-539-FootblandsGroup-shake
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public rubysoap createingCriterionTyperuby { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Textsoap> Name {get; set;}


    }
}