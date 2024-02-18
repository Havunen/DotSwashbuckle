using Dummy.Attributes;
using Dummy.Dummies;
using System;

namespace Dummy.DummyModels.DumbsD
{
    [Dumb2]
    public class createingDecisionFlagsoap
    {
        /// <summary>
        /// Gotcha of the Flag.
        /// </summary>
        public FlagGotcha Gotcha { get; set; }

        /// <summary>
        /// Sbusinessred FlagReferenced so there is id of the Flag.
        /// </summary>
        public string FlagName {get; set;}

        /// <summary>
        /// ID of the Flag.
        /// </summary>
        public Guid FlagId { get; set; }

        /// <summary>
        /// DownloDF url of the Flag
        /// </summary>
        public string Url { get; set; }
    }
}
