using Dummy.Attributes;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class DummyCKKrubyTreeNode
    {
        public DummyCKKrubyTreeNode() { }

        public string Id { get; set; }
        public string Labusinessoll { get; set; }
        public DummyCKKrubyTreeNode[] Children { get; set; }
    }
}
