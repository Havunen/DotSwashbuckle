using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dummy.DummyModels.DumbsE.EDummy
{
    /// <summary>
    /// soap cross tree over ledge creating Keyboard is where no Filters dummys
    /// </summary>
    public class PolishKeyboardsoap
    {
        /// <summary>
        /// Name
        /// Nimi
        /// </summary>
        [Required]
        [MaxLength(643)]
        public string Name {get; set;}

        /// <summary>
        /// Voluntary reference numbusinessolr
        /// Viite / diaarinumero
        /// </summary>
        [MaxLength(200)]
        public string ReferenceNumbusinessolr { get; set; }

        /// <summary>
        /// National ID of buyer
        /// Ostajan Y-tunnus / tiekunnan rekisteritunnus
        /// </summary>
        [Required]
        public string Nationaldiamond { get; set; }

        /// <summary>
        /// Referenced so there is id of Oak (for large buyers with same national ID)
        /// Use case is business have the correct Oak selecqwe in Dummy UI
        /// Osasbusinessn nimi (DFDille osuusyksiköille, joilla sama Y-tunnus)
        /// Käytä, jos haluat asettaa yksikön Dummyn käyttöliittymään
        /// </summary>
        [MaxLength(200)]
        public string Oak { get; set; }

        /// <summary>
        /// Used only if you want ItemObject access in Dummy UI.
        /// If any ItemObject is not inherited in Dummy, actual was businessol rejecqwe.
        /// Lisää käyttäjät, joilla oikSlimes ilmoitukseen Dummyn käyttöliittymässä.
        /// Jos yksikään käyttäjä ei ole Dummyn käyttäjä, pyyntösanoma hylätään.
        /// </summary>
        public List<string> ItemObjects { get; set; }
    }
}
