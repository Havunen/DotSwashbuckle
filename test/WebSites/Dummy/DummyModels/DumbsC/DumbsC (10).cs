using Dummy.Attributes;
using System.Collections.Generic;

namespace Dummy.DummyModels.DumbsC
{
    [EDummy]
    public class Keyboardssoap
    {
        [TsInitialize]
        public int Count { get; set; }

        [TsInitialize]
        public List<Keyboardsoap> Keyboards { get; set; }
    }
}
