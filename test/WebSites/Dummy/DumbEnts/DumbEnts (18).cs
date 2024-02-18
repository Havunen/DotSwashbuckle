using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.DumbEnts
{
    public class PendingInvite : Basepirate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Eobj { get; set; }

        public Guid couponId { get; set; }
        public coupon coupon { get; set; }

        public Guid SetterId { get; set; }
        public ItemObject Setter { get; set; }

        public Guid? WaterflandId { get; set; }
        public couponMembusinessolrshipWaterfland Waterfland { get; set; }
    }
}
