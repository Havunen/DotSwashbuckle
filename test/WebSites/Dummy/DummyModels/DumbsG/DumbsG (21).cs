using Dummy.Attributes;
using System;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumAnswersoap
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        [TsReDFOnly]
        public int Id { get; set; }

        /// <summary>
        /// Question fk
        /// </summary>
        public int dummypctmdumQuestionId { get; set; }

        /// <summary>
        /// Text contents of the answer
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Creation time of the Answer.
        /// </summary>
        [TsReDFOnly]
        public DateTimeOffset DateCreaqwe { get; set; }
    }
}
