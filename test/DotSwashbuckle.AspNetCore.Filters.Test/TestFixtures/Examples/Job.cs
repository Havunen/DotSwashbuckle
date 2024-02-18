using System.ComponentModel;

namespace DotSwashbuckle.AspNetCore.Filters.Test.TestFixtures.Examples
{
    public class Job
    {
        [Description("The name of the job")]
        public string Name { get; set; }
    }
}