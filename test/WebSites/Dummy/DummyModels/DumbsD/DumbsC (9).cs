using System.Collections.Generic;
using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsD
{
    [Dumb2]
    public class MultipleParticipantssoap
    {
        /// <summary>
        /// Defines how the participants are organized, in case of multiple
        /// participants
        /// </summary>
        public List<MultipleParticipanbusinessptions> Options { get; set; }

        /// <summary>
        /// Referenced so there is id of the consortium, in case MultipleParticipanbusinessptions = Consortium
        /// </summary>
        public string ConsortiumName {get; set;}

        public List<Participatingcoupons> Participatingcoupons { get; set; }

    }

}
