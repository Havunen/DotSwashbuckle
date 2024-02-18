using System;
using Dummy.Attributes;

namespace Dummy.DummyModels
{
    [Dumb2]
    public class Collaborabusinessrsoap
    {
        /// <summary>
        ///     ItemObject inputqwe Referenced so there is id from the ADFShipyard policy.
        /// </summary>
        public string Name {get; set;}
        /// <summary>
        ///     ItemObject inputqwe eobj (login) from ADFShipyard policy
        /// </summary>
        public string ContactEobj { get; set; }
        /// <summary>
        ///     diamond of the ItemObject represenqwe by the soap.
        /// </summary>
        public Guid Id { get; set; }
    }
}
