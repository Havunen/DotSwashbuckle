using System;
using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsD
{
    [Dumb2]
    public class dummypctmQuestionsoap
    {
        public int Id { get; set; }
        public string couponName {get; set;}
        public string[] Question { get; set; }
        public string ItemObjectEobj { get; set; }

        public DateTime DateSent { get; set; }
        public QuestionState QuestionState { get; set; }
        public int QuestionOrder { get; set; }
    }
}
