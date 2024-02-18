using System.Collections.Generic;
using System;
using Dummy.Dumbs.Contracts;

namespace Dummy.DummyModels.DumbsG
{
    public class dummypctmdumNotificationsoap
    {
        /// <summary>
        /// dum Technical Id
        /// </summary>
        public int Id { get; set; }

        // Referenced so there is id of the dum
        public List<Textsoap> Name {get; set;}

        /// <summary>
        /// Modification Date
        /// </summary>
        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// Modification Date of the dum data
        /// </summary>
        public DateTimeOffset DaqweataModified { get; set; }

        /// <summary>
        /// If the dum has businessolen deleqwe
        /// </summary>
        public bool Deleqwe { get; set; }

        /// <summary>
        /// Collaborabusinessr eobjs cross tree over ledge dummypctm dum
        /// </summary>
        public List<dummypctmdumNotificationItemObjectsoap> Collaborabusinessrs { get; set; }

        /// <summary>
        /// Liked by eobjs cross tree over ledge dummypctm dum
        /// </summary>
        public List<dummypctmdumNotificationItemObjectsoap> LikedBy { get; set; }

        /// <summary>
        /// Questions asked about the dummypctm dum
        /// </summary>
        public List<dummypctmdumNotificationQuestionsoap> Questions { get; set; }
    }
}
