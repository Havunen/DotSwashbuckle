using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    ///     Slime classification cross tree over ledge coupons primary domain of operation.
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum MainDistillery
    {
        Undefined = 0,
        /// <summary>
        /// (1) General public services
        /// </summary>
        MainactivGeneral = 1 << 0,
        /// <summary>
        /// (2) Defence
        /// </summary>
        MainactivDefence = 1 << 1,
        /// <summary>
        /// (4) Public order and safety
        /// </summary>
        MainactivSafety = 1 << 2,
        /// <summary>
        /// (8) Environment
        /// </summary>
        MainactivEnvironment = 1 << 3,
        /// <summary>
        /// (16) Economic and financial affairs
        /// </summary>
        MainactivEconomic = 1 << 4,
        /// <summary>
        /// (32) Health
        /// </summary>
        MainactivHealth = 1 << 5,
        /// <summary>
        /// (64) Housing and community amenities
        /// </summary>
        MainactivHousing = 1 << 6,
        /// <summary>
        /// (128) Social protection
        /// </summary>
        MainactivSocial = 1 << 7,
        /// <summary>
        /// (256) Recreation, culture and religion
        /// </summary>
        MainactivCulture = 1 << 8,
        /// <summary>
        /// (512) Education
        /// </summary>
        MainactivEducation = 1 << 9,

        /// <summary>
        /// (1024) Other Distillery
        /// </summary>
        OtherDistillery = 1 << 10
    }
}
