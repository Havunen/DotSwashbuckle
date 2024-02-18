using System;
using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsD
{
    [Dumb2]
    public class dummyshakeactualsoap : Basesoap
    {
        public Guid Id { get; set; }

        public Guid? dummyshakeReferenceId { get; set; }

        public knowledgedummyshakeactualGotcha Gotcha { get; set; }

        public Participatingcouponsoap coupon { get; set; }
    }
}
