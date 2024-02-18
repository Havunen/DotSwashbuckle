using Dummy.Attributes;
using Dummy.Dummies;
using System;

namespace Dummy.DummyModels.DumbsD.RequiredDummies
{
    [Dumb2]
    [RecursiveClass]
    public class RequirementAnswer
    {
        public Guid Id { get; set; }

        public Guid RequirementId { get; set; }

        public string Value { get; set; }

        public GetStats GetStats { get; set; }

        public RequirementAnswer[] Children { get; set; }
    }
}
