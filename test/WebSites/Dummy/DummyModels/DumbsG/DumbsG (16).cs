using System;
using Dummy.Dummies.Dummies4;

namespace Dummy.DummyModels.DumbsG
{
    public class Avpdummypctmdumsoap
    {
        /// <summary>
        /// dum Technical Id
        /// </summary>
        public int Id { get; set; }

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
    }
}
