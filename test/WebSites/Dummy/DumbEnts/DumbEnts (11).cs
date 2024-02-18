using System;

namespace Dummy.DumbEnts
{
    public class Feedback
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? ItemObjectId { get; set; }
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;
        public int? Ranking { get; set; }
        public string Message { get; set; }
        public int? EdummyId { get; set; }
        public int? EdummyKeyboardId { get; set; }
        public string EdummyType { get; set; }
        public Guid? knowledgeId { get; set; }
        public int? RegulatedactualId { get; set; }
        public int? RegulatedlongermessageId { get; set; }
        public int? dummypctmdumId { get; set; }
    }
}
