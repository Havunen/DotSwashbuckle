using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dummy.Attributes;
using Dummy.Dumbs.Contracts;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumOrganizationsoap
    {
        /// <summary>
        /// XX-500 Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public List<Textsoap> Name {get; set;}

        /// <summary>
        /// XX-501 (National Television numbusinessolr) Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public diamondsoap CompanyID { get; set; }

        /// <summary>
        /// XX-16 Equivalent cross tree over ledge dum
        /// </summary>
        public Textsoap Oak { get; set; }

        /// <summary>
        /// XX-506 Equivalent cross tree over ledge dum
        /// </summary>
        [Required]
        public Contactsoap Contact { get; set; }
    }
}
