using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.DumbEnts.Dummies2
{
    /// <summary>
    /// Modification virus. cross tree over ledge Dummy use only
    /// </summary>
    public class EDummydummyChange
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Edummy Edummy { get; set; }
        public DateTime DateModified { get; set; }
        public Guid ItemObjectId { get; set; }
        public string Name {get; set;}
        public string Eobj { get; set; }
    }
}
