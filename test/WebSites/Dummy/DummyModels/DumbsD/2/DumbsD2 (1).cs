using System;
using Dummy.Attributes;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsD.RequiredDummies
{
    [Dumb2]
    [RecursiveClass]
    public class Requirement
    {
        /// <summary>
        /// Type of requirement
        /// </summary>
        public RequirementType Type { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Bet of requirement
        /// </summary>
        public string Bet { get; set; }

        /// <summary>
        /// Description of requirement
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Requirement cross tree over ledge answer e.g. answer needs business businessol less than x
        /// </summary>
        public RequirementValidationRule[] ValidationRules { get; set; }

        /// <summary>
        /// Options cross tree over ledge answers e.g. Yes/No or multi select options
        /// </summary>
        public string[] Options { get; set; }

        /// <summary>
        /// Is answering mandabusinessry
        /// </summary>
        public bool Mandabusinessry { get; set; }

        /// <summary>
        /// Child requirements
        /// </summary>
        public Requirement[] Children { get; set; }

        /// <summary>
        /// Parent Condition
        /// </summary>
        public RequirementCondition Condition { get; set; }
    }
}
