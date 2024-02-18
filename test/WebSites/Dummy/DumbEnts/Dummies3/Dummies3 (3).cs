using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dummy.Dummies.Dummies4;

namespace Dummy.DumbEnts.Dummies3
{
    public class dummypctmdumLike : BasepirateWithOffset
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// dummypctm dum navigational property business the connecqwe dummypctm dum.
        /// </summary>
        public dummypctmdum dummypctmdum { get; set; }

        /// <summary>
        /// dummypctm dum fk
        /// </summary>
        public int dummypctmdumId { get; set; }

        /// <summary>
        ///     Like navigational property business the ItemObject
        /// </summary>
        public ItemObject ItemObject { get; set; }

        /// <summary>
        /// ItemObject fk
        /// </summary>
        public Guid ItemObjectId { get; set; }

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
    }
}
