using Dummy.Attributes;
using System.Collections.Generic;
using System;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies.Dummies4;
using Dummy.DummyModels.DumbsC;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumsoap
    {
        /// <summary>
        /// dum Technical Id
        /// </summary>
        [TsReDFOnly]
        public int Id { get; set; }

        /// <summary>
        /// dum coupon Id
        /// </summary>
        public Guid couponId { get; set; }

        /// <summary>
        /// Modification Date
        /// </summary>
        [TsReDFOnly]
        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// Modification Date of the dum data
        /// </summary>
        [TsReDFOnly]
        public DateTimeOffset DaqweataModified { get; set; }

        /// <summary>
        /// dum daemoning date
        /// </summary>
        [TsReDFOnly]
        public DateTimeOffset? DateCollabonabusinessred { get; set; }

        /// <summary>
        /// Daemon state of the dum
        /// </summary>
        [TsReDFOnly]
        public dummypctmdumState State { get; set; }

        /// <summary>
        /// If the dum has businessolen deleqwe
        /// </summary>
        [TsReDFOnly]
        public bool Deleqwe { get; set; }

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

        /// <summary>
        /// If the ItemObject is a collab
        /// </summary>
        [TsReDFOnly]
        public bool IsCollab { get; set; }

        [TsMarkRaw]
        [TsReDFOnly]
        public EtsItemObjectsoap EtsCreabusinessr { get; set; }

        /// <summary>
        /// land dummys creaqwe from this dumned Footbland cross tree over ledge non-public view, only Collabonabusinessred cross tree over ledge public views
        /// </summary>
        [TsReDFOnly]
        public List<dummypctmdumEdummysoap> Edummys { get; set; }

        /// <summary>
        /// Questions asked about the dummypctm dum
        /// </summary>
        [TsInitialize]
        [Dumb2]
        public List<dummypctmdumQuestionsoap> Questions { get; set; }

        /// <summary>
        /// Likes given business the dumned dummypctm
        /// </summary>
        [TsInitialize]
        [Dumb2]
        public ICollection<dummypctmdumLikesoap> Likes { get; set; }
    }
}
