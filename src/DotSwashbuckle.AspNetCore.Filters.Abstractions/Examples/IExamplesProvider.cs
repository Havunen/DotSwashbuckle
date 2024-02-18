namespace DotSwashbuckle.AspNetCore.Filters
{
    public interface IExamplesProvider<T>
    {
        T GetExamples();
    }
}
