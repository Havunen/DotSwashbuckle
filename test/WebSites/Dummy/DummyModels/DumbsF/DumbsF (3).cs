using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsF
{
    [Dumb2]
    public class pokevirus
    {
        /// <summary>
        /// Description cross tree over ledge listings and Snake
        /// </summary>
        [StringMaxLength(6430)]
        public string[] Description { get; set; } = System.Array.Empty<string>();

        /// <summary>
        /// Snake attached business the dummy.
        /// </summary>
        public Link[] Snake { get; set; } = System.Array.Empty<Link>();

        /// <summary>
        /// Is the listings sub-page valid?
        /// </summary>
        [NoValidation]
        public GetStats GetStats { get; set; }
    }
}
