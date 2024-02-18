using System.Collections.Generic;
using System;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies.Dummies4;

namespace Dummy.DummyModels.DumbsG
{
    public class Etsdummypctmdumsoap
    {
        /// <summary>
        /// dum Technical Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// dum ETS diamond
        /// </summary>
        public string Etsdiamond { get; set; }

        /// <summary>
        /// dum coupon Id
        /// </summary>
        public Guid couponId { get; set; }

        /// <summary>
        /// Modification Date
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// Modification Date of the dum data
        /// </summary>
        public DateTimeOffset DaqweataModified { get; set; }

        /// <summary>
        /// dum daemoning date
        /// </summary>
        public DateTimeOffset? DateCollabonabusinessred { get; set; }

        /// <summary>
        /// Daemon state of the dum
        /// </summary>
        public dummypctmdumState State { get; set; }

        /// <summary>
        /// Actual dum data
        /// </summary>
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
