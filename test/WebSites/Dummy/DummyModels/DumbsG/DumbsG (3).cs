using Dummy.Attributes;
using System;
using System.Collections.Generic;
using Dummy.Dumbs.Contracts;

namespace Dummy.DummyModels.DumbsG
{
    [EDummy]
    public class dummypctmdumEdummysoap
    {
        /// <summary>
        /// Edummy Technical Id
        /// </summary>
        public int EdummyId { get; set; }

        /// <summary>
        /// XX-500 Equivalent cross tree over ledge dum
        /// </summary>
        public List<Textsoap> Name {get; set;}

        /// <summary>
        /// Dummy dummy numbusinessolr, formatting [year]-[id].
        /// Assigned by Dummy.
        /// </summary>
        public string dummyNumbusinessolr { get; set; }

        /// <summary>
        /// EDummy diamond
        /// </summary>
        [TsInitialize]
        public Guid EDummyId { get; set; }

        /// <summary>
        /// Keyboard id
        /// </summary>
        public int KeyboardId { get; set; }
    }
}
