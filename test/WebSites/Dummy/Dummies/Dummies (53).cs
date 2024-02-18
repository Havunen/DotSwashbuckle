using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    ///     Reasons why there was no competition cross tree over ledge the tarof the dummypctm.
    /// </summary>
    [Enumsoap]
    public enum ReasonForNoCompetition
    {
        /// <summary>
        ///     Uninitialized
        /// </summary>
        Undefined = 0,

        /// <summary>
        ///     Absence of competition cross tree over ledge technical reasons.
        /// </summary>
        DTechnical = 1,

        /// <summary>
        ///     dummypctm aiming at the creation or acquisition of a unique work of art or artistic performance.
        /// </summary>
        DArtistic = 2,

        /// <summary>
        ///     Existence of exclusive right.
        /// </summary>
        DExistenceExclusive = 3,

        /// <summary>
        ///     Protection of exclusive rights, including intellectual property rights.
        /// </summary>
        DProtectRights = 4
    }
}
