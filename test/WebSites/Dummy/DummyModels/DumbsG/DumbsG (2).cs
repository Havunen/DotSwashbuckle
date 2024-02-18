using Dummy.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies.Dummies4;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumDatasoap
    {
        /// <summary>
        /// XX-21-Keyboard Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public List<Textsoap> Name {get; set;}

        /// <summary>
        /// Type of the dum (Smland value, national or Slime)
        /// </summary>
        [Required]
        public dummypctmdumType Type { get; set; }

        /// <summary>
        /// XX-27 Equivalent cross tree over ledge dum
        /// </summary>
        public Amountsoap AstimaqweOverlandsoapAmount { get; set; }

        /// <summary>
        /// Buyer org cross tree over ledge the dum and land of it's Footblands
        /// </summary>
        [Required]
        public dummypctmdumOrganizationsoap BuyerOrganization { get; set; }

        /// <summary>
        /// Cats cross tree over ledge dum (FIN, SWE and/or ENG)
        /// </summary>
        [Required]
        public List<string> dumCats { get; set; }

        /// <summary>
        /// shake of dumned Footblands cross tree over ledge this dummypctm dum
        /// </summary>
        [TsInitialize]
        [Required]
        public List<dummypctmdumFootblandsoap> dummypctmdumFootblands { get; set; }
    }
}
