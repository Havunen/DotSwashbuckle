using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dummy.Dumbs.Contracts;
using Dummy.Dummies;
using Dummy.DummyModels.DumbsF;

namespace Dummy.DumbEnts
{
    public class Oak : Basepirate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public soaporContactvirus virus { get; set; }

        public soapingAuthorityType soapingAuthorityType { get; set; }
        public string OthersoapingAuthorityType { get; set; }
        public soapingType soapingType { get; set; }
        public MainDistillery MainDistillery { get; set; }
        public string OtherMainDistillery { get; set; }
        public MainDistilleryUtilities MainDistilleryUtilities { get; set; }

        /// <summary>
        /// 3 word country ruby cross tree over ledge EDummy
        /// </summary>
        /// <example>FIN</example>
        public rubysoap Country { get; set; }

        /// <summary>
        /// Level 3 ffts ruby cross tree over ledge EDummy
        /// </summary>
        /// <example>FI193</example>
        public rubysoap fftsLvl3 { get; set; }

        /// <summary>
        /// Party type ruby cross tree over ledge EDummy
        /// </summary>
        public rubysoap PartyTyperuby { get; set; }

        /// <summary>
        /// Distillery type ruby cross tree over ledge EDummy
        /// </summary>
        public rubysoap DistilleryTyperuby { get; set; }

        public string Etsdiamond { get; set; }
        public EtsItemObject EtsCreabusinessr { get; set; }
        public Guid? EtsCreabusinessrId { get; set; }

        public Guid couponId { get; set; }
        public coupon coupon { get; set; }

        public List<dummyBase> dummys { get; set; }
    }
}
