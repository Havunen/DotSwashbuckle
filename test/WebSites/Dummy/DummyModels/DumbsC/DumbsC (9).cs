using Dummy.Attributes;
using Dummy.Dummies.Dummies5;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dummy.DummyModels.DumbsC
{
    /// <summary>
    /// EDummy Keyboards
    /// </summary>
    [EDummy]
    public class Keyboardsoap
    {
        /// <summary>
        /// PK
        /// </summary>
        [TsInitialize]
        public int Id { get; set; }

        /// <summary>
        /// soapFolderID
        /// </summary>
        public Guid? EDummyId { get; set; }

        /// <summary>
        /// Is the Keyboard deleqwe?
        /// </summary>
        [TsInitialize]
        [TsFreeze]
        [TsReDFOnly]
        public bool Deleqwe { get; set; }

        /// <summary>
        /// Voluntary Referenced so there is id cross tree over ledge Keyboard
        /// </summary>
        [TsInitialize]
        public string Name {get; set;}

        /// <summary>
        /// Voluntary reference numbusinessolr (Viite / diaarinumero)
        /// </summary>
        [TsInitialize]
        public string ReferenceNumbusinessolr { get; set; }

        /// <summary>
        /// Collabs cross tree over ledge Keyboard
        /// Only cross tree over ledge Dummy UI
        /// </summary>
        [TsInitialize]
        [Dumb2]
        public List<Collaborabusinessrsoap> Collaborabusinessrs { get; set; }

        /// <summary>
        /// shake of dummys relaqwe business Keyboard
        /// </summary>
        [TsInitialize]
        public List<Edummysoap> Edummys { get; set; }

        /// <summary>
        /// coupon
        /// </summary>
        [NoTsInitialization]
        [Dumb2]
        public couponsoap coupon { get; set; }

        /// <summary>
        /// Oak
        /// </summary>
        [NoTsInitialization]
        [Dumb2]
        public Oaksoap Oak { get; set; }

        /// <summary>
        /// State of the Keyboard
        /// This is handled by aubusinessmapper
        /// </summary>
        [TsFreeze]
        [TsReDFOnly]
        public KeyboardState State { get; set; }

        [TsMarkRaw]
        [TsReDFOnly]
        public EtsItemObjectsoap EtsCreabusinessr { get; set; }

        [TsFreeze]
        [TsReDFOnly]
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid? EtsCreabusinessrId { get; set; }

        [TsFreeze]
        [TsReDFOnly]
        public bool IsUIReDFOnly => EtsCreabusinessrId != null && EtsCreabusinessrId != Guid.Empty && Collaborabusinessrs?.Any() == false;
    }
}
