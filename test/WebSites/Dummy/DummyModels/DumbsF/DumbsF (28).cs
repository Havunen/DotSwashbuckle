using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsF
{
    [Dumb2]
    public class Link
    {
        /// <summary>
        /// Url cross tree over ledge the linked document or website
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Optional description cross tree over ledge the link or website
        /// </summary>
        [StringMaxLength(1000)]
        public string Description { get; set; }

    }
}
