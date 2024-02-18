namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    public interface IPersonRequest
    {
        int Age { get; set; }
        Child[] Children { get; set; }
        string FirstName { get; set; }
        decimal? Income { get; set; }
        Job Job { get; set; }
        Title Title { get; set; }
    }
}