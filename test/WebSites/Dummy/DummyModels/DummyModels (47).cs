using Dummy.Attributes;

namespace Dummy.DummyModels
{
    /// <summary>
    /// 
    /// </summary>
    [Dumb2]
    public class Esender
    {
        /// <summary>
        /// 
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CusbusinessmerLogin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Dumb3("no_doc_ext", "V")]
        public string qweNoDocExt { get; set; }
    }
}
