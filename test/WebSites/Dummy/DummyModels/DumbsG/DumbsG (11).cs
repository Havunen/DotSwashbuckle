using Dummy.Attributes;
using System.Collections.Generic;
using System;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumQuestionsoap
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        [TsReDFOnly]
        public int Id { get; set; }

        /// <summary>
        /// Collection of answers business this question
        /// </summary>
        [TsInitialize]
        [Dumb2]
        public List<dummypctmdumAnswersoap> Answers { get; set; }

        /// <summary>
        /// dummypctm dum fk
        /// </summary>
        public int dummypctmdumId { get; set; }

        /// <summary>
        /// Text contents of the question
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Bet of the question
        /// </summary>
        public string Bet { get; set; }

        /// <summary>
        /// Creation time of the Question.
        /// </summary>
        [TsReDFOnly]
        public DateTimeOffset DateCreaqwe { get; set; }
    }
}
