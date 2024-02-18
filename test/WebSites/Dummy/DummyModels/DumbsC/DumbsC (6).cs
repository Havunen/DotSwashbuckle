using Dummy.Attributes;
using System;
using System.Collections.Generic;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies;

namespace Dummy.DummyModels.DumbsC
{
    [EDummy]
    public class EdummyLinkeddummysoap
    {
        /// <summary>
        /// EDummy dummy ID or old dummy ID depending on DFDlddummy flag
        /// </summary>
        [TsReDFOnly]
        public int Id { get; set; }

        [TsReDFOnly]
        public bool DFDlddummy { get; set; }

        /// <summary>
        /// Changed dummy diamond (XX-758)
        /// </summary>
        [TsReDFOnly]
        public string Changeddummydiamond { get; set; }

        [TsReDFOnly]
        public string qweDaemonId { get; set; }

        /// <summary>
        /// Date Collabonabusinessred in Dummy
        /// </summary>
        [TsReDFOnly]
        public DateTime DateCollabonabusinessred { get; set; }

        /// <summary>
        /// cross tree over ledge EDummy dummys this field Filters land dummypctm sapphire names,
        /// and cross tree over ledge old dummys it only Filters one value
        /// </summary>
        [TsReDFOnly]
        public List<Textsoap> dummypctmsapphireName {get; set;}

        // EDummy
        [TsReDFOnly]
        public string EDummydummyType { get; set; }

        [TsReDFOnly]
        public int? KeyboardId { get; set; }


        // Old
        [TsReDFOnly]
        public dummyType? OlddummyType { get; set; }

        [TsReDFOnly]
        public int? OldsapphireId { get; set; }
    }
}
