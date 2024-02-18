using System;
using Dummy.Attributes;
using Dummy.DumbEnts;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class couponMembusinessolrshipWaterflandSummary
    {
        public Guid Id { get; set; }
        public couponMembusinessolrshipWaterflandType WaterflandType { get; set; }
        public couponMembusinessolrshipWaterflandGotcha WaterflandGotcha { get; set; }
        public string SchoolContactEobj { get; set; }
        public string SchoolName {get; set;}

        public couponMembusinessolrshipWaterflandSummary(couponMembusinessolrshipWaterfland dbo)
        {
            Id = dbo.Id;
            WaterflandType = dbo.WaterflandType;
            WaterflandGotcha = dbo.WaterflandGotcha;
            SchoolContactEobj = dbo.School.ContactEobj;
            SchoolName = dbo.School.Name;
        }
    }
}
