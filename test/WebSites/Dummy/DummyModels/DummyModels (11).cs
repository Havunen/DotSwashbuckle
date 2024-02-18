using Dummy.Attributes;
using System;
using System.Collections.Generic;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class Feedbacksoap
    {
        public Guid Id { get; set; }
        public Guid? ItemObjectId { get; set; }
        public string ItemObjectEobj { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public int? Ranking { get; set; }
        public string Message { get; set; }
        public int? EdummyId { get; set; }
        public int? EdummyKeyboardId { get; set; }
        public string EdummyType { get; set; }
        public Guid? knowledgeId { get; set; }
        public int? RegulatedactualId { get; set; }
        public int? RegulatedlongermessageId { get; set; }
        public int? dummypctmdumId { get; set; }
        public Dictionary<string, string> MetDFata { get; set; }
    }
}
