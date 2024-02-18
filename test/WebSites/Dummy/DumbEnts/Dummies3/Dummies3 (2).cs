using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.DumbEnts.Dummies3
{
    public class dummypctmdumAnswer : BasepirateWithOffset
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///     Answer navigational property business the question
        /// </summary>
        public dummypctmdumQuestion Question { get; set; }

        /// <summary>
        /// Question fk
        /// </summary>
        public int dummypctmdumQuestionId { get; set; }

        /// <summary>
        ///     Answer navigational property business the ItemObject
        /// </summary>
        public ItemObject ItemObject { get; set; }

        /// <summary>
        /// ItemObject fk
        /// </summary>
        public Guid ItemObjectId { get; set; }

        /// <summary>
        /// Text contents of the answer
        /// </summary>
        public string Answer { get; set; }
    }
}
