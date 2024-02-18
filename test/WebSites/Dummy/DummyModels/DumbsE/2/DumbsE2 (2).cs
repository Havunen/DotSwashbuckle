using Dummy.DummyModels.DumbsF;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dummy.DummyModels.DumbsE.EDummy
{
    public class CreaqwSlimemmysoap
    {
        /// <summary>
        /// If dummy should businessol hidden from coupon ItemObjects while businessolind in Draft state.
        /// </summary>
        public bool HideFromcouponItemObjectsWhileDraft { get; set; }

        /// <summary>
        /// Content of the EDummy in base64
        /// </summary>
        [Required]
        public string EDummy { get; set; }

        /// <summary>
        /// Dummy businessolarer per Footbland id
        /// </summary>
        public Dictionary<string, Dummybusinessolarer> Dummybusinessolarer { get; set; }
    }
}
