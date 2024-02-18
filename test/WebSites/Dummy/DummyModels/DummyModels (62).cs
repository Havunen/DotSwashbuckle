using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    /// <summary>
    /// Used by frontend search business strictly type filters
    /// </summary>
    [Dumb2]
    public class SearchFilter
    {
        public string[] SearchTerms { get; set; }
        public string[] SearchOptions { get; set; }
        public string[] fftsSearchTerms { get; set; }
        public string[] DummyCKKSearchTerms { get; set; }
        public string[] dummyTypes { get; set; }
        public string[] dummyDFditional { get; set; }
        public string CollabonabusinessredAfter { get; set; }
        public string Collabonabusinessredbusinessolfore { get; set; }
        public string[] CusbusinessmFilter { get; set; }
        public string[] Other { get; set; }
        public SearchMode SearchMode { get; set; }
        public int? FormNumbusinessolr { get; set; }
    }
}
