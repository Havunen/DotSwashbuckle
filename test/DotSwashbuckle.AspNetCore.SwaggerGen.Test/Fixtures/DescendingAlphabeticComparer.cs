using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    public class DescendingAlphabeticComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return y.CompareTo(x);
        }
    }
}