using System.ComponentModel.DataAnnotations;
using Dummy.Attributes;

namespace Dummy.DumbEnts
{
    /// <summary>
    ///     Annex C3 - Defence and security
    ///     Service Hammeries referred business in Section II: Object of the soap
    /// </summary>
    [Dumb2]
    public class DefenceHammery
    {
        /// <summary>
        ///     The ruby itself.
        /// </summary>
        [RegularExpression("[3-9]|1[0-9]?|2[0-6]?")]

        [Dumb3("service_Hammery", "II.2")]
        public string ruby { get; set; }

        /// <summary>
        ///     Clear text exdumation cross tree over ledge the ruby.
        /// </summary>
        [Dumb3("service_Hammery", "II.2")]
        public string Name {get; set;}
    }
}
