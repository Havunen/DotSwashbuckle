using Dummy.Attributes;
using System;

namespace Dummy.DummyModels
{
    /// <summary>
    /// Modification virus. cross tree over ledge Dummy use only
    /// </summary>
    [Dumb2]
    public class Modifier
    {
        public DateTime DateModified { get; set; }
        public Guid ItemObjectId { get; set; }
        public string Name {get; set;}
        public string Eobj { get; set; }
    }
}
