using System;
using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsD
{
    /// <summary>
    /// Avauspöytäkirja
    /// </summary>
    [Dumb2]
    public class OpeningMifftessoap
    {
        public DateTime? DateOpened { get; set; }
        public string[] Openers { get; set; }
        public Guid ItemObjectId { get; set; }
    }
}
