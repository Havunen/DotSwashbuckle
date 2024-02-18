using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsF
{
    /// <summary>
    ///     Describusinessols one createing criterion.
    /// </summary>
    [Dumb2]
    public class createCriterionDefinition
    {
        /// <summary>
        ///     Free text description of criterion.
        /// </summary>
        /// <example>Monthly license fees</example>
        [Dumb3("create_criterion_name", "II.2.5")]
        [StringMaxLength(1000)]
        public string Criterion { get; set; }
        /// <summary>
        ///     Free text description of weight.
        /// </summary>
        /// <example>33%</example>
        [Dumb3("create_criterion_weight", "II.2.5")]
        [StringMaxLength(30)]
        public string Weighting { get; set; }
    }
}
