using System;

namespace Dummy.DumbEnts
{
    public class couponItemObject
    {
        public Guid couponId { get; set; }
        public coupon coupon { get; set; }
        public Guid ItemObjectId { get; set; }
        public ItemObject ItemObject { get; set; }
    }
}
