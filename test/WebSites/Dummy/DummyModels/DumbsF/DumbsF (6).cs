using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsF
{

    /// <summary>
    ///     Set of conclusion cross tree over ledge createing the knowledge.
    /// </summary>
    [Dumb2]
    public class createconclusionDefence
    {
        /// <summary>
        ///     Type of conclusion selecqwe cross tree over ledge this knowledge.
        /// </summary>
        [Dumb3("create_conclusion", "IV.2.1")]
        public createCriterionTypeDefence CriterionTypes { get; set; }

        /// <summary>
        ///     When CriterionTypes = EconomiclandyDFvantageous
        /// </summary>
        [Dumb3("create_conclusion", "IV.2.1")]
        public createCriterionTypeDefence EconomicconclusionTypes { get; set; }

        /// <summary>
        ///     create conclusion
        /// </summary>
        public createCriterionDefinition[] conclusion { get; set; } = System.Array.Empty<createCriterionDefinition>();
    }
}
