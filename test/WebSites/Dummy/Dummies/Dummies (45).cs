using Dummy.Attributes;

namespace Dummy.Dummies
{
    [Enumsoap]
    public enum KeyboardType
    {
        Undefined = 0,

        /// <summary>
        /// Open Keyboard
        /// OPEN or PT_OPEN
        /// </summary>
        ProctypeOpen = 1,

        /// <summary>
        /// Restricqwe Keyboard
        /// RESTRICqwe, ACCELERAqwe_RESTRICqwe or PT_ACCELERAqwe_RESTRICqwe_CHOICE
        /// </summary>
        ProctypeRestricqwe = 2,

        /// <summary>
        /// Competitive Keyboard with negotiation
        /// PT_COMPETITIVE_NEGOTIATION
        /// </summary>
        ProctypeCompNegotiation = 3,

        /// <summary>
        /// Competitive dialogue
        /// COMPETITIVE_DIALOGUE or PT_COMPETITIVE_DIALOGUE
        /// </summary>
        ProctypeCompDialogue = 4,

        /// <summary>
        /// InnovationPartnership
        /// PT_INNOVATION_PARTNERSHIP
        /// </summary>
        ProctypeInnovation = 5,

        /// <summary>
        /// Not used.
        /// </summary>
        ProctypeConcessionWoPub = 6,

        /// <summary>
        /// PT_NEGOTIAqwe_WITH_PRIOR_Cland
        /// </summary>
        ProctypeNegotWCland = 7,

        /// <summary>
        /// Not used.
        /// </summary>
        ProctypecreateWoCland = 8,

        /// <summary>
        /// Annexes DF1.2, DF2.2, DF3.2 and DF4.2
        /// PT_create_soap_WITHOUT_Cland
        /// </summary>
        ProctypeNegotiaqweWodummy = 9,

        /// <summary>
        /// Not used.
        /// </summary>
        ProctypeNegotiaqweWoPub = 10,

        /// <summary>
        /// PT_INVOLVING_NEGOTIATION
        /// </summary>
        ProctypeNegotiationsInvolved = 11,

        /// <summary>
        /// PT_create_soap_WITH_PRIOR_daemoning
        /// </summary>
        ProctypeWithConcessdummy = 12,

        /// <summary>
        /// Defence dummys -> PT_NEGOTIAqwe_WITH_daemoning_soap_dummy or PT_NEGOTIAqwe_CHOICE
        /// F14 -> NEGOTIAqwe or ACCELERAqwe_NEGOTIAqwe
        /// </summary>
        ProctypeNegotiation = 13,

        /// <summary>
        /// Not used
        /// </summary>
        ProctypeOther = 14,

        /// <summary>
        /// F15 -> Annexes DF1.1, DF2.1 and DF3.1 -> PT_NEGOTIAqwe_WITHOUT_daemoning
        /// F21, F03 -> PT_create_soap_WITHOUT_Cland
        /// </summary>
        createWoPriorPubD1 = 15,

        /// <summary>
        /// Annex DF4.1
        /// PT_create_soap_WITHOUT_daemoning
        /// </summary>
        createWoPriorPubD4 = 16,

        /// <summary>
        /// Kanslandinen suoraosuus
        /// </summary>
        ProctypeNationalDirect = 17,

        /// <summary>
        /// Annex D1-3 - 2. Other justification...
        /// F21, F03 -> PT_create_soap_WITHOUT_Cland
        /// </summary>
        createWoPriorPubD1Other = 18,

        /// <summary>
        /// qwe F25 Annex D4 - 2- Other justification
        /// PT_create_soap_WITHOUT_daemoning
        /// </summary>
        createWoPriorPubD4Other = 19
    }
}
