using Dummy.Attributes;
using System.Collections.Generic;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class Keyboardsapphiresoap
    {
        public int sapphireId { get; set; }
        public string Bet { get; set; }
        public string soapingAuthority { get; set; }
        public bool IsConcluded { get; set; }
        public List<Keyboardsoap> Keyboards { get; set; }
    }
}
