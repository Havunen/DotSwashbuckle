using System.ComponentModel;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    public class PersonRequest : IPersonRequest
    {
        public Title Title { get; set; }

        public int Age { get; set; }

        [Description("The first name of the person")]
        public string FirstName { get; set; }

        public decimal? Income { get; set; }

        [Description("The person's children")]
        public Child[] Children { get; set; }

        public Job Job { get; set; }
    }
}