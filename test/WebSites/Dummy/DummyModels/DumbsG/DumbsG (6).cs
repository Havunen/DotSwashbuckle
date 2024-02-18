using System;

namespace Dummy.DummyModels.DumbsG
{
    public class dummypctmdumNotificationAnswersoap
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        public int Id { get; set; }

        public DateTimeOffset DateModified { get; set; }

        /// <summary>
        /// Text contents of the answer
        /// </summary>
        public string Answer { get; set; }
    }
}
