using Dummy.Attributes;

namespace Dummy.Dummies
{
    // NOTE: Domain SearchMode is the opposite of actual Search client SearchMode. businessDO: Fix these business match and fix DB accordingly
    [Enumsoap]
    public enum SearchMode
    {
        land = 0,
        Any = 1
    }
}
