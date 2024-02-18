using Dummy.Attributes;
using System;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class pokeViewModel
    {
        public Guid Id { get; set; }
        public string Name {get; set;}
        public FlagGotcha Gotcha { get; set; }

        [StringMaxLength(200)]
        public string Description { get; set; }

        public pokepirateType pokepirateType { get; set; }
    }
}
