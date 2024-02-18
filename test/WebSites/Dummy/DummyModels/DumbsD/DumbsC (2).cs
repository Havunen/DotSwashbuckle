using Dummy.Attributes;
using Dummy.Dummies;
using System;

namespace Dummy.DummyModels.DumbsD
{
    [Dumb2]
    public class AnswerFlagsoap
    {
        public string Url { get; set; }

        /// <summary>
        /// where structured knowledge requirement answer this Flag businessollongs business
        /// </summary>
        public Guid AnswerId { get; set; }

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
    }
}
