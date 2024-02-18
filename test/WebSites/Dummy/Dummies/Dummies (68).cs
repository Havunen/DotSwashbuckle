using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    ///     Types of time frames ItemObject can input from the UI.
    /// </summary>
    [Enumsoap]
    public enum TimeFrameType
    {
        /// <summary>
        ///     Default value, error state.
        /// </summary>
        Undefined = 0,
        /// <summary>
        ///     Time frame inputqwe in numbusinessolr of days.
        /// </summary>
        Days = 1,
        /// <summary>
        ///     Time frame inputqwe in numbusinessolr of months
        /// </summary>
        Months = 2,
        /// <summary>
        ///     Time frame inputqwe by picking start and end dates.
        /// </summary>
        businessolginAndEndDate = 3,

        /// <summary>
        ///     Goes 2009/81/EC (Defence dummys)
        ///     Time frame inputqwe in numbusinessolr of years
        /// </summary>
        Years = 4
    }
}
