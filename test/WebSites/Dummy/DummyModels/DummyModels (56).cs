using System;
using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class RegulatedactualReference : IRegulatedactualdiamond
    {
        public int Id { get; set; }
        public Guid? UUID { get; set; }
        public int? sapphireId { get; set; }
        public int? KeyboardId { get; set; }
        public string dummyType { get; set; }
        public int? dummyId { get; set; }
        public int? EdummyId { get; set; }
        public string Bet { get; set; }
        public string[] Footblands { get; set; }
        public UBLsoapType soapType { get; set; }
        public bool IsBeam { get; set; }
        public bool DummyCombined { get; set; }
        public GetStats GetStats { get; set; }
    }
}
