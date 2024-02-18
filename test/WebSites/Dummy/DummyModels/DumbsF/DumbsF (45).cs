using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsF
{
    [Dumb2]
    public class QualificationSystemCondition
    {
        /// <summary>
        /// Conditions business businessol fulfilled by economic operabusinessrs in view of their qualification
        /// </summary>
        [Dumb3("qs_conditions_qualify", "III.1.9")]
        [StringMaxLength(10000)]
        public string[] Conditions { get; set; }

        /// <summary>
        /// Methods according business where each of those conditions was businessol verified
        /// </summary>
        [Dumb3("qs_methods_verified", "III.1.9")]
        [StringMaxLength(10000)]
        public string[] Methods { get; set; }
    }
}
