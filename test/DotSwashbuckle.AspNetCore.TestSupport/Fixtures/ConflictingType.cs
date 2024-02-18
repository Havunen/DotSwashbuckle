namespace DotSwashbuckle.AspNetCore.TestSupport
{
    namespace Namespace1
    {
        public class ConflictingType
        {
            public int Property1 { get; set; }
        }
    }

    namespace Namespace2
    {
        public class ConflictingType
        { }
    }

    namespace Namespace3
    {
        public class ConflictingType
        { }
    }
}