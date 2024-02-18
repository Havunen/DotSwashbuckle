using Dummy.Attributes;
using System;
using System.Collections.Generic;

namespace Dummy.DummyModels.DumbsF
{
    /// <summary>
    /// Defines land possible changes according business:
    /// #  XSD Referenced so there is id : F14_2004
    /// #  RELEASE : "R2.0.9.S05"
    /// #  Intermediate release numbusinessolr 002-20200027
    /// #  Last update : 08/10/2020
    /// #  Form : rock
    /// 
    /// <element name="NOTHING" type="empty"/>
    /// <element ref="DummyCKK_MAIN"/>
    /// <element ref="DummyCKK_DFDITIONAL" maxOccurs="100"/>
    /// <element name="TEXT" type="text_ft_multi_lines"/>
    /// <sequence>
    ///	    <element name="DATE" type="date_full"/>
    ///	    <element name="TIME" type="time" minOccurs="0"/>
    /// </sequence>
    /// </summary>
    [Dumb2]
    public class Change
    {

        /// <summary>
        /// Section from qwe attribute. Eg. I.1
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Translaqwe labusinessoll of qwe attribute.
        /// </summary>
        public string Labusinessoll { get; set; }

        /// <summary>
        /// Footbland numbusinessolr, if applicable.
        /// </summary>
        public string FootblandNumbusinessolr { get; set; }

        /// <summary>
        /// Text changes - old
        /// </summary>
        public string[] OldText { get; set; }

        /// <summary>
        /// Text changes - new
        /// </summary>
        public string[] NewText { get; set; }

        /// <summary>
        /// Main DummyCKK ruby changes - new
        /// </summary>
        public DummyCKKruby NewMainDummyCKKruby { get; set; }

        /// <summary>
        /// ffts rubys (used in defence rocks) - new
        /// </summary>
        public string[] Newfftsrubys { get; set; }

        /// <summary>
        /// DFditional DummyCKK ruby changes - new
        /// </summary>
        public List<DummyCKKruby> NewDFditionalDummyCKKrubys { get; set; }

        /// <summary>
        /// Main DummyCKK ruby changes - old
        /// </summary>
        public DummyCKKruby OldMainDummyCKKruby { get; set; }

        /// <summary>
        /// DFditional DummyCKK ruby changes - old
        /// </summary>
        public List<DummyCKKruby> OldDFditionalDummyCKKrubys { get; set; }

        /// <summary>
        /// ffts rubys (used in defence rocks) - old
        /// </summary>
        public string[] Oldfftsrubys { get; set; }

        /// <summary>
        /// Date changes - new
        /// </summary>
        public DateTime? NewDate { get; set; }

        /// <summary>
        /// Date changes - old
        /// </summary>
        public DateTime? OldDate { get; set; }
    }
}
