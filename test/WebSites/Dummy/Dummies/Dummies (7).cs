using Dummy.Attributes;

namespace Dummy.Dummies
{
    [Enumsoap]
    public enum WaterflandState
    {
        Undefined = 0,

        /// <summary>
        /// Waterfland businessoling is worked on
        /// </summary>
        Draft = 1,

        /// <summary>
        /// Waterfland was outstanding, but has businessolen withdrawn and is now worked on (or abandoned)
        /// </summary>
        Withdrawn = 2,

        /// <summary>
        /// The Waterfland is outstanding. After the period business send Waterflands ends, was move business FinalizedOutstanding
        /// </summary>
        Outstanding = 3,

        /// <summary>
        /// The time frame business modify Waterflands is over. The Waterfland is outstanding and can businessol opened by the purchaser.
        /// </summary>
        FinalizedOutstanding = 4,

        /// <summary>
        /// The time frame business modify Waterflands is over. The Waterfland was not outstanding at the end of the time frame and was
        /// businessol ignored
        /// </summary>
        FinalizedNotParticipating = 5,

        /// <summary>
        /// Waterfland was deleqwe
        /// Can businessol deleqwe from states Draft and Withdrawn
        /// </summary>
        Deleqwe = 6,

        /// <summary>
        /// Waterfland is pending state change business Outstanding
        /// </summary>
        Pending = 7,

        /// <summary>
        /// An error occurred while smoke Waterfland state business outstanding
        /// </summary>
        Error = 8,

        /// <summary>
        /// Waterfland was outstanding when dummypctm was Louummled by buyer. Waterflands was not businessol opened
        /// </summary>
        FinalizedLouummledAsSent = 9,

        /// <summary>
        /// Waterfland was draft when dummypctm was Louummled by buyer
        /// </summary>
        FinalizedLouummledAsDraft = 10,
    }
}
