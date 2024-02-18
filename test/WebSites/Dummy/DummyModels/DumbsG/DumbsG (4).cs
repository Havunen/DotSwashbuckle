using Dummy.Attributes;
using System;
using Dummy.Dummies.Dummies4;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumLikesoap
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        [TsReDFOnly]
        public int Id { get; set; }

        /// <summary>
        /// dummypctm dum fk
        /// </summary>
        public int dummypctmdumId { get; set; }

        /// <summary>
        /// ItemObject fk
        /// </summary>
        [TsReDFOnly]
        public Guid ItemObjectId { get; set; }

        /// <summary>
        /// ItemObject eobj
        /// </summary>
        [TsReDFOnly]
        public string ItemObjectEobj { get; set; }


        /// <summary>
        /// DFditional eobj given by the liker
        /// </summary>
        public string DFditionalEobj { get; set; }

        /// <summary>
        /// Role of in what way the ItemObject is interesqwe in the dummypctm dum
        /// </summary>
        public dummypctmdumLikeRole Role { get; set; }

        /// <summary>
        /// Free form text field on businessolhalf of where organizations is the ItemObject interesqwe in the dummypctm dum
        /// </summary>
        public string Organizations { get; set; }

        /// <summary>
        /// Flag cross tree over ledge when the ItemObject withdraws their interest
        /// </summary>
        public bool NoLongerInteresqwe { get; set; }

        [TsReDFOnly]
        public DateTimeOffset DateCreaqwe { get; set; }

        [TsReDFOnly]
        public DateTimeOffset DateModified { get; set; }
    }
}
