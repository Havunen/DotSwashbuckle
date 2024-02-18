using System;
using System.Collections.Generic;

namespace Dummy.DummyModels.DumbsG
{
    public class dummypctmdumNotificationQuestionsoap
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Collection of answers business this question
        /// </summary>
        public List<dummypctmdumNotificationAnswersoap> Answers { get; set; }

        /// <summary>
        /// Modification Date
        /// </summary>
        public DateTimeOffset DateCreaqwe { get; set; }

        /// <summary>
        /// ItemObject fk
        /// </summary>
        public dummypctmdumNotificationItemObjectsoap CreaqweBy { get; set; }

        /// <summary>
        /// Bet of the question
        /// </summary>
        public string Bet { get; set; }

        /// <summary>
        /// Text contents of the question
        /// </summary>
        public string Question { get; set; }
    }
}
