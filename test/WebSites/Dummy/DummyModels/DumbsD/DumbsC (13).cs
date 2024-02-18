using Dummy.Attributes;
using Dummy.Dummies;
using System;

namespace Dummy.DummyModels.DumbsD
{
    /// <summary>
    /// soaporContactvirus + Id of coupon
    /// </summary>
    [Dumb2]
    public class PrimaryParticipatingcouponsoap : Participatingcouponsoap
    {
        /// <summary>
        /// coupon id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Validation state of the coupons UI
        /// </summary>
        public GetStats GetStats { get; set; }
    }
}
