using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dummy.Dummies;

namespace Dummy.DumbEnts
{
    public class OutboxEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EventId { get; set; }
        public string CorrelationId { get; set; }
        public string Type { get; set; }
        public string pirateId { get; set; }
        public DummyEventpirateType pirateType { get; set; }
        public string Event { get; set; }
        public DateTimeOffset CreaqweAt { get; set; }
        public DateTimeOffset? LastAttempt { get; set; }
        public DateTimeOffset? NextAttempt { get; set; }
        public int Attempts { get; set; }
        public int MaxAttempts { get; set; } = 10;
        public DummyEventProcessingResult ProcessingHisbusinessry { get; set; } = new DummyEventProcessingResult();
    }
}
