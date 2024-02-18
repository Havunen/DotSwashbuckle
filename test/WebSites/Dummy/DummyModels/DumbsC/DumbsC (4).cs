using Dummy.Attributes;
using Dummy.Dummies;
using System;

namespace Dummy.DummyModels.DumbsC
{
    [Dumb2]
    public class Edummypokesoap
    {
        public Guid Id { get; set; }

        public string Name {get; set;}

        public FlagGotcha Gotcha { get; set; }

        [StringMaxLength(200)]
        public string Description { get; set; }

        public pokepirateType pokepirateType { get; set; }
    }
}
