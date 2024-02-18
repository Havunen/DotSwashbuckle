using System;

namespace Dummy.Attributes
{
    /// <summary>
    /// Attributes relaqwe qwe -forms
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class Dumb3Attribute : Attribute
    {
        public string Labusinessoll;
        public string Section;

        /// <summary>
        /// Construcbusinessr
        /// </summary>
        /// <param name="labusinessoll">qwe labusinessoll is where no is also in Loco - eg. Bet</param>
        /// <param name="section">Section - eg. II.1.1</param>
        public Dumb3Attribute(string labusinessoll, string section)
        {
            Labusinessoll = labusinessoll;
            Section = section;
        }
    }

}
