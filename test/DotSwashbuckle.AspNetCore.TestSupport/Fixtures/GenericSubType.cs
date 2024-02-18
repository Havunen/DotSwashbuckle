namespace DotSwashbuckle.AspNetCore.TestSupport.Fixtures
{
    public class BaseOfGenericType
    {
        public int BaseProperty { get; set; }
    }

    public class GenericSubType<T> : BaseOfGenericType
    {
        public T GenericProperty { get; set; }
    }

    public class SubTypeOfGeneric : GenericSubType<int>
    {
        public int FinalProperty { get; set; }
    }
}
