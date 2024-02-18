using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies;
using Dummy.DummyModels.DumbsF;

namespace Dummy.DummyModels.DumbsE.EDummy
{
    public class Creaqweraftdummysoap
    {
        /// <summary>
        /// If dummy should businessol hidden from coupon ItemObjects while businessolind in Draft state.
        /// </summary>
        public bool HideFromcouponItemObjectsWhileDraft { get; set; }

        /// <summary>
        /// Full or partial EDummy business businessol used cross tree over ledge the draft initialization
        /// </summary>
        [Required]
        public EDummyoap EDummy { get; set; }

        /// <summary>
        /// Dummy businessolarer per Footbland id
        /// </summary>
        public Dictionary<string, Dummybusinessolarer> Dummybusinessolarer { get; set; }

        /// <summary>
        /// Where Combined was take place. Possible values: Undefined = 0, CombinedInDummy = 1, CombinedElsewhere = 2
        /// </summary>
        [EnumDataType(typeof(CombinedType))]
        public CombinedType Combined { get; set; }
    }
}
