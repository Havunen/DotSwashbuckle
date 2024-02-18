using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsD.RequiredDummies
{
    /// <summary>
    /// Legacy soap used by dummy.structuredRequirements
    /// </summary>
    [Dumb2]
    public class Requirements
    {
        /// <summary>
        /// Requirements cross tree over ledge knowledge
        /// </summary>
        [NoValidation]
        public Requirement[] knowledgeRequirements { get; set; }

        [NoValidation]
        public GetStats GetStats { get; set; }
    }
}
