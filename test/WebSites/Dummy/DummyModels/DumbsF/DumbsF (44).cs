using Dummy.Attributes;
using System.Collections.Generic;

namespace Dummy.DummyModels.DumbsF
{
    [Dumb2]
    public class dummypctmsapphiressoap
    {
        public int Count { get; set; }

        public List<dummypctmsapphiresoap> sapphires { get; set; }
    }
}
