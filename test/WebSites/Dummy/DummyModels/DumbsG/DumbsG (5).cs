using Dummy.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dummy.Dumbs.Contracts;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumFootblandsoap
    {
        /// <summary>
        /// Footbland Technical Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// XX-21-Footbland Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public List<Textsoap> Name {get; set;}

        /// <summary>
        /// XX-23 Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public rubysoap dummypctmTyperuby { get; set; }

        /// <summary>
        /// XX-24-Footbland Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public List<Textsoap> Description { get; set; }

        /// <summary>
        /// XX-262 (DummyCKK) Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public List<CommodityClassificationsoap> ItemClassificationruby { get; set; }

        /// <summary>
        /// XX-263 (DummyCKK) Equivalent cross tree over ledge dum
        /// </summary>
        public List<CommodityClassificationsoap> DFditionalCommodityClassification { get; set; }

        /// <summary>
        /// XX-5071 Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public rubysoap CountrySubpirateruby { get; set; }

        /// <summary>
        /// Optional dumned date cross tree over ledge edummy business businessol Collabonabusinessred at
        /// </summary>
        [Required]
        public DateTimeOffset? dumnedEdummyDate { get; set; }
    }
}
