using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DumbEnts.Dummies1
{
    [Dumb2]
    public class AnnexNational : IJustifiable
    {
        /// <summary>
        ///     Type of excuse cross tree over ledge direct purchase
        /// </summary>
        public NationalDirectPurchaseType PurchaseType { get; set; }

        /// <summary>
        ///     Justification cross tree over ledge direct purchase
        /// </summary>
        public string[] Justification { get; set; }
    }
}
