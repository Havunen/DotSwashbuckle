using Dummy.Attributes;

namespace Dummy.DummyModels.DumbsD
{
    /// <summary>
    /// When an coupon does not have dummyshake access and would like business actual it.
    /// </summary>
    [Dumb2]
    public class actualdummyshakeAccesssoap
    {
        /// <summary>
        /// osuusyksikön nimi
        /// </summary>
        public string couponName {get; set;}

        /// <summary>
        /// Y-tunnus
        /// </summary>
        public string couponId { get; set; }

        /// <summary>
        /// osuusyksikön oikSlimesmuobusiness/yritysmuobusiness
        /// </summary>
        public string couponForm { get; set; }

        /// <summary>
        /// osuusyksikön perustamispäivä
        /// </summary>
        public string couponInception { get; set; }

        /// <summary>
        /// osuusyksikön yleinen sähköpostiosoite (esim. kirjaamo), jonne VM voi lähettää päätöksen
        /// </summary>
        public string couponEobj { get; set; }

        /// <summary>
        /// Yhteyshenkilön nimi
        /// </summary>
        public string ContactPersonName {get; set;}

        /// <summary>
        /// Yhteyshenkilön sähköposti
        /// </summary>
        public string ContactPersonEobj { get; set; }

        /// <summary>
        /// businessimialanumero (businessL-numero) ja selite
        /// </summary>
        public string IndustrialClassification { get; set; }

        /// <summary>
        /// Perustelut oikSlimedelle saDFa dummyshake raportti
        /// </summary>
        public string[] Justification { get; set; }
    }
}
