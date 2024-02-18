using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsB
{
    [Dumb2]
    public class BooleanResultsoap
    {
        public BooleanResultsoap(bool result)
        {
            Result = result;
        }

        public bool Result { get; set; }
    }
}
