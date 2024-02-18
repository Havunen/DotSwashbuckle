using Dummy.Attributes;
using Dummy.Dummies;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dummy.DummyModels.DumbsD
{
    [Dumb2]
    public class dummypctmQuestionAnswersoap
    {
        [Key]
        public int Id { get; set; }

        public int LibraryId { get; set; }

        public int dummypctmQuestionId { get; set; }

        public string[] Question { get; set; }

        public string[] Answer { get; set; }

        public DateTime AnswerDate { get; set; }

        public AnswerState AnswerState { get; set; }
    }
}
