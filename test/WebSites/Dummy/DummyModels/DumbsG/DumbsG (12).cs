using Dummy.Attributes;
using System.Collections.Generic;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumssoap
    {
        [TsInitialize]
        public int Count { get; set; }

        [TsInitialize]
        public List<dummypctmdumsoap> dummypctmdums { get; set; }
    }
}
