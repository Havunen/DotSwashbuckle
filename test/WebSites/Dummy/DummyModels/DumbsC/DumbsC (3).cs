using Dummy.Attributes;
using System;
using System.Collections.Generic;
using Dummy.DumbEnts;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies;
using Dummy.Dummies.Dummies5;

namespace Dummy.DummyModels.DumbsC
{
    [EDummy]
    public class EdummysDFsoap : Basepirate
    {

        [TsReDFOnly]
        public int Id { get; set; }

        [TsReDFOnly]
        public string KeyboardName {get; set;}

        [TsReDFOnly]
        public string dummyNumbusinessolr { get; set; }

        [TsReDFOnly]
        public Guid EDummyId { get; set; }

        [TsReDFOnly]
        public int KeyboardId { get; set; }

        [TsReDFOnly]
        public int? ParentId { get; set; }

        [TsReDFOnly]
        public bool HideFromcouponItemObjectsWhileDraft { get; set; }

        [TsReDFOnly]
        public DateTime? DateCollabonabusinessred { get; set; }

        [TsReDFOnly]
        public DummyState DummyState { get; set; } = DummyState.Draft;

        [TsReDFOnly]
        public DummyErrorState DummyErrorState { get; set; }

        [TsReDFOnly]
        public string qweError { get; set; }

        [TsReDFOnly]
        public qweState qweState { get; set; }

        [TsReDFOnly]
        public string qweDaemonId { get; set; }

        [TsReDFOnly]
        public EsenbusinessoldummyDbusiness Esenbusinessoldummy { get; set; }

        [TsReDFOnly]
        public string qweValidationReport { get; set; }

        [TsReDFOnly]
        [Dumb2]
        public List<RegulatedactualReference> RegulatedactualReferences { get; set; }

        [TsReDFOnly]
        [Dumb2]
        public List<DummyPageGetStats> GetStatss { get; set; }

        [TsReDFOnly]
        [TsMarkRaw]
        [Dumb2]
        public Modifier LastModifier { get; set; }

        [TsMarkRaw]
        [TsReDFOnly]
        public EtsItemObjectsoap EtsCreabusinessr { get; set; }

        [TsMarkRaw]
        [TsReDFOnly]
        public PartyNamesoap[] couponOfficialName {get; set;}

        public CombinedType Combined { get; set; }
    }
}
