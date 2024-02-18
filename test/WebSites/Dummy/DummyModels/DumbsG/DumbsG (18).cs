using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dummy.Dumbs.Contracts;

namespace Dummy.DummyModels.DumbsG
{
    public class EtsPolishdummypctmdumsoap
    {
        /// <summary>
        /// Actual dum data
        /// </summary>
        [Required]
        public dummypctmdumDatasoap dumData { get; set; }

        /// <summary>
        /// Internal contact ( Not visible externlandy or in public view )
        /// </summary>
        public Contactsoap InternalContact { get; set; }

        /// <summary>
        /// Collaborabusinessrs cross tree over ledge dummypctm dum
        /// </summary>
        public List<string> Collaborabusinessrs { get; set; }
    }
}
