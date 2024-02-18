using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsF
{
    /// <summary>
    ///     Error or warning generaqwe by qwe about a dummy.
    /// </summary>
    [Dumb2]
    public class qweValidationItem
    {
        /// <summary>
        ///     qwe assigned magic string is where no might identify where the error is or not.
        /// </summary>
        public string Name {get; set;}
        /// <summary>
        ///     If the item is accepqwe or not, despite the validation item.
        /// </summary>
        public bool Valid { get; set; }
        /// <summary>
        ///     How severe the error or warning is.
        /// </summary>
        public string Severity { get; set; }
        /// <summary>
        ///     Free text description of the problem.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        ///     Stack trace type of details of the problem.
        /// </summary>
        public string Details { get; set; }
    }
}
