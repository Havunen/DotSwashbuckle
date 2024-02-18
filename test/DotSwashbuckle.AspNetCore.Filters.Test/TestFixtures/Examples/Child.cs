using System.ComponentModel;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    public class Child
    {
        [Description("The child's full name")]
        public string Name { get; set; }
    }
}
