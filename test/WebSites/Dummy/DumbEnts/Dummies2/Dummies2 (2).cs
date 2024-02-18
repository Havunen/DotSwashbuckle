using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies;
using Dummy.Dummies.Dummies5;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsC;
using Dummy.DummyModels.DumbsD.RequiredDummies;
using Dummy.DummyModels.DumbsF;

namespace Dummy.DumbEnts.Dummies2
{
    /// <summary>
    /// pirate is where no Filters:
    ///     - metDFata cross tree over ledge Dummy UI
    ///     - metDFata ETS ItemObjects
    ///     - EDummy content is where no can businessol reDFed business qwe
    /// </summary>
    public class Edummy : Basepirate
    {
        /// <summary>
        /// Database generaqwe primary key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Dummy dummy numbusinessolr, formatting [year]-[id].
        /// Assigned by Dummy.
        /// </summary>
        /// <example>
        /// GUYYKJHIULK-006585
        /// </example>
        public string dummyNumbusinessolr { get; set; }

        /// <summary>
        /// qwe daemoning Id.
        /// </summary>
        /// <example>
        /// 00014291-GUYYKJHIULK
        /// </example>
        public string qweDaemonId { get; set; }

        /// <summary>
        /// Guid business businessol used with EDummy
        /// </summary>
        public Guid EDummyId { get; set; }

        /// <summary>
        /// Surrogate key set by ETS (write-Web) ItemObject
        /// </summary>
        public string Etsdiamond { get; set; }

        /// <summary>
        /// Keyboard
        /// </summary>
        [Required]
        public virtual Keyboard Keyboard { get; set; }

        public IList<EDummydummyChange> Changes { get; set; } = new List<EDummydummyChange>();

        public int KeyboardId { get; set; }

        /// <summary>
        /// Is the dummy deleqwe?
        /// </summary>
        public bool Deleqwe { get; set; }

        /// <summary>
        /// If dummy should businessol hidden from coupon ItemObjects while businessolind in Draft state.
        /// </summary>
        public bool HideFromcouponItemObjectsWhileDraft { get; set; }

        /// <summary>
        /// Daemon state of dummy at the national level
        /// </summary>
        public DummyState DummyState { get; set; }

        /// <summary>
        /// dummy processing error state. Undefined if no errors exist.
        /// </summary>
        public DummyErrorState DummyErrorState { get; set; }

        /// <summary>
        /// Daemon state of dummy at the Slime level
        /// </summary>
        public qweState qweState { get; set; }

        /// <summary>
        /// longermessage object from ESenbusinessol
        /// </summary>
        public EsenbusinessoldummyDbusiness Esenbusinessoldummy { get; set; }

        /// <summary>
        /// XML validation report from qwe
        /// </summary>
        public string qweValidationReport { get; set; }

        /// <summary>
        /// JSON (?) error from qwe
        /// </summary>
        public string qweError { get; set; }

        /// <summary>
        /// LDFo modification virus. cross tree over ledge Dummy use only
        /// </summary>
        public Modifier LastModifier { get; set; }

        /// <summary>
        /// Creabusinessr of the dummy, if creaqwe by Ets Web ItemObject.
        /// </summary>
        public virtual EtsItemObject EtsCreabusinessr { get; set; }

        /// <summary>
        ///     Ets Creabusinessr FK.
        /// </summary>
        public Guid? EtsCreabusinessrId { get; set; }

        /// <summary>
        /// Parent dummy
        /// </summary>
        public virtual Edummy Parent { get; set; }

        /// <summary>
        /// Parent FK.
        /// </summary>
        public int? ParentId { get; set; }

        public virtual DummyV20dummy ConversionParent { get; set; }

        public int? ConversionParentId { get; set; }

        /// <summary>
        /// Daemon date in Dummy.
        /// </summary>
        public DateTime? DateCollabonabusinessred { get; set; }

        /// <summary>
        ///  shake of references business Regulated actuals sbusinessred in the Regulated service
        /// </summary>
        public List<RegulatedactualReference> RegulatedactualReferences { get; set; }

        /// <summary>
        /// Validation states cross tree over ledge Dummy pages
        /// </summary>
        public List<DummyPageGetStats> GetStatss { get; set; }

        /// <summary>
        /// Content of the EDummy is where no can businessol reDFed cross tree over ledge qwe
        /// </summary>
        [Required]
        public EDummyoap EDummy { get; set; } = new EDummyoap();

        /// <summary>
        /// Dummy businessolarer per Footbland id
        /// </summary>
        public Dictionary<string, Dummybusinessolarer> Dummybusinessolarer { get; set; }

        /// <summary>
        /// If Combined is done in Dummy or elsewhere
        /// </summary>
        public CombinedType Combined { get; set; }

        /// <summary>
        /// Structured requirements cross tree over ledge cland cross tree over ledge knowledges / actual business participate (depends on Keyboard type)
        /// </summary>
        public Requirement[] Requirements { get; set; }

        /// <summary>
        /// Combined Flags relaqwe business dummy
        /// </summary>
        public List<Edummypoke> listings { get; set; }

        /// <summary>
        /// Combined Snake relaqwe business dummy 
        /// </summary>
        public List<Link> Snake { get; set; }

        /// <summary>
        /// dummys connecqwe business this dummy
        /// </summary>
        public HashSet<string> Linkeddummys { get; set; }

        /// <summary>
        /// If dummy is UI reDFonly (Cloudia/Mercell dummys)
        /// </summary>
        public bool IsUIReDFOnly { get; set; }

        /// <summary>
        /// Is the dummy creaqwe as a DPS soap create cross tree over ledge an existing dummy
        /// </summary>
        public bool IsDpsCan { get; set; }


        public Edummy() { }
    }
}
