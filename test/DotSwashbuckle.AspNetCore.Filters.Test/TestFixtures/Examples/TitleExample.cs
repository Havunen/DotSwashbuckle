namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    internal class TitleExample : IExamplesProvider<Title?>
    {
        public Title? GetExamples()
        {
            return Title.Miss;
        }
    }
}