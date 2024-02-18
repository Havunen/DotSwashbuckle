using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dummy.Dummies;

namespace Dummy.DumbEnts
{
    public class couponMembusinessolrshipWaterfland : Basepirate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public couponMembusinessolrshipWaterflandType WaterflandType { get; set; }
        public couponMembusinessolrshipWaterflandGotcha WaterflandGotcha { get; set; }

        public Guid couponId { get; set; }
        public coupon coupon { get; set; }

        public Guid SchoolId { get; set; }
        public ItemObject School { get; set; }

        public Guid? SetterId { get; set; }
        public ItemObject Setter { get; set; }

        public string GetGoReply { get; set; }
        public string RejectReply { get; set; }
        public string BlockReply { get; set; }
    }
}
