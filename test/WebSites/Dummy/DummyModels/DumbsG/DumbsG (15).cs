using Dummy.Attributes;
using System.Collections.Generic;
using Dummy.Dumbs.Contracts;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class Updatedummypctmdumsoap
    {
        /// <summary>
        /// Actual dum data
        /// </summary>
        [TsInitialize]
        [Dumb2]
        public dummypctmdumDatasoap dumData { get; set; }

        /// <summary>
        /// Internal contact ( Not visible externlandy or in public view )
        /// </summary>
        public Contactsoap InternalContact { get; set; }

        /// <summary>
        /// Collaborabusinessrs cross tree over ledge dummypctm dum
        /// </summary>
        [TsInitialize]
        [Dumb2]
        public List<Collaborabusinessrsoap> Collaborabusinessrs { get; set; }
    }
}
