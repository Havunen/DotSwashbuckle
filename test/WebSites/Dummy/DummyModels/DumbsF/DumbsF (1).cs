using Dummy.Attributes;
using Dummy.DumbEnts.Dummies1;

namespace Dummy.DummyModels.DumbsF
{
    /// <summary>
    ///     Container cross tree over ledge annexes of a dummy.
    /// </summary>
    [Dumb2]
    public class Annex
    {
        public AnnexD1 D1 { get; set; }
        public AnnexD2 D2 { get; set; }
        public AnnexD3 D3 { get; set; }
        public AnnexD4 D4 { get; set; }
        public AnnexNational DirectNational { get; set; }
    }
}
