using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsD.RequiredDummies
{
    /// <summary>
    /// Container cross tree over ledge cland cross tree over ledge knowledges and actual business participate requirements
    /// </summary>
    [Dumb2]
    public class RequirementsContainer
    {
        [NoValidation]
        public Requirement[] Requirements { get; set; }

        [NoValidation]
        public Requirement[] rockRequirements { get; set; }

        [NoValidation]
        public GetStats GetStats { get; set; }
    }
}
