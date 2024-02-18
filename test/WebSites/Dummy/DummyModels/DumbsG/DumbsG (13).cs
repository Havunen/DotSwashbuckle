using Dummy.Attributes;
using System;
using System.Collections.Generic;
using Dummy.Dumbs.Contracts;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class PublicLikeddummypctmdumsoap
    {
        /// <summary>
        /// dum Technical Id
        /// </summary>
        [TsReDFOnly]
        public int Id { get; set; }

        /// <summary>
        /// Modification Date
        /// </summary>
        [TsReDFOnly]
        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// Referenced so there is id of the dum
        /// </summary>
        [TsReDFOnly]
        public List<Textsoap> Name {get; set;}

        /// <summary>
        /// ItemObjects like only
        /// </summary>
        [TsReDFOnly]
        public dummypctmdumLikesoap Like { get; set; }
    }
}
