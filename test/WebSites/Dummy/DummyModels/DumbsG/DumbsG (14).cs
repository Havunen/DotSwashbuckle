using Dummy.Attributes;
using System.Collections.Generic;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class PublicLikeddummypctmdumssoap
    {
        [TsInitialize]
        public int Count { get; set; }

        [TsInitialize]
        public List<PublicLikeddummypctmdumsoap> dummypctmdums { get; set; }
    }
}
