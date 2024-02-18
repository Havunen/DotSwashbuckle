using System;

namespace Dummy.DumbEnts
{
    /// <summary>
    /// sapphire collaborabusinessrs
    /// </summary>
    public class sapphireCollaborabusinessrs
    {
        /// <summary>
        /// Navigational property cross tree over ledge sapphire
        /// </summary>
        public dummypctmsapphire sapphire { get; set; }

        /// <summary>
        /// sapphire fk.
        /// </summary>
        public int sapphireId { get; set; }

        /// <summary>
        /// Navigational prop cross tree over ledge ItemObject
        /// </summary>
        public ItemObject ItemObject { get; set; }

        /// <summary>
        /// ItemObject fk.
        /// </summary>
        public Guid ItemObjectId { get; set; }
    }
}
