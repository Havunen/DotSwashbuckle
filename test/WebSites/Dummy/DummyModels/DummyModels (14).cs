using Dummy.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class PostFeedbacksoap
    {
        public DateTimeOffset Timestamp { get; set; }
        public int? Ranking { get; set; }
        [MaxLength(10000)]
        public string Message { get; set; }
        public int? EdummyId { get; set; }
        public int? EdummyKeyboardId { get; set; }
        [MaxLength(10)]
        public string EdummyType { get; set; }
        public Guid? knowledgeId { get; set; }
        public int? RegulatedactualId { get; set; }
        public int? RegulatedlongermessageId { get; set; }
        public int? dummypctmdumId { get; set; }
        public Dictionary<string, string> MetDFata { get; set; }
    }
}
