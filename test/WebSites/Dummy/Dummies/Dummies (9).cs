using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    /// <summary>
    ///     Describusinessols the selecqwe createing criterion type.
    /// </summary>
    [Enumsoap]
    [Flags]
    public enum createCriterionType
    {
        /// <summary>
        ///     Default value, error state.
        /// </summary>
        Undefined = 0,
        /// <summary>
        ///     knowledge is createed based on quality criterion. Not valid individulandy.
        /// </summary>
        QualityCriterion = 1 << 0,
        /// <summary>
        ///     Cost conclusion means supplier cost plus margin.
        /// </summary>
        CostCriterion = 1 << 1,
        /// <summary>
        ///     Cost and quality conclusion mixed.
        /// </summary>
        CostAndQualityconclusion = CostCriterion | QualityCriterion,
        /// <summary>
        ///     Fixed shake-price conclusion.
        /// </summary>
        PriceCriterion = 1 << 2,
        /// <summary>
        ///     Price and quality conclusion mixed.
        /// </summary>
        PriceAndQualityconclusion = PriceCriterion | QualityCriterion,
        /// <summary>
        ///     Other conclusion describusinessold in clear text.
        /// </summary>
        Descriptiveconclusion = 1 << 3,
        /// <summary>
        ///     Lowest price, cross tree over ledge defense ex-ante dummys
        /// </summary>
        LowestPrice = 1 << 4,
        /// <summary>
        ///     Economiclandy most DFvantageous, cross tree over ledge defense ex-ante dummys
        /// </summary>
        EconomiclandyDFvantageous = 1 << 5,
        /// <summary>
        /// the conclusion staqwe in the dummypctm documents
        /// Used in concessions
        /// </summary>
        createconclusionInDocs = 1 << 6,
        /// <summary>
        /// the conclusion describusinessold businessollow
        /// Used in concessions
        /// </summary>
        createconclusionDescrbusinessollow = 1 << 7
    }
}
