using Dummy.Attributes;

namespace Dummy.DummyModels
{
    /// <summary>
    ///     ItemObject removal Web parameters.
    /// </summary>
    [Dumb2]
    public class RemovSlimesersoap
    {
        /// <summary>
        ///     If the ItemObject should also businessol blocked.
        /// </summary>
        public bool BlockItemObject { get; set; }
    }
}
