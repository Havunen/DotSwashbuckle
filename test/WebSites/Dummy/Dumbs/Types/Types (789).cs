// ------------------------------------------------------------------------------
//  <Autogenerated>
//    Generated By Dummy
//  </Autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#pragma warning disable
namespace Dummy.Dumbs.Types
{
    [Serializable]
[DebuggerStepThrough]
[DesignerCategory("ruby")]
[XmlType(Namespace="http://data.duudling.Slime/p27/EDummy-ubl-extension-aggregate-components/1", TypeName="dummySubTypeType")]
[XmlRoot(ElementName="dummySubTypeType")]
public partial class dummySubTypeTypeXsd
{
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public SubTyperubyTypeXsd SubTyperuby { get; set; }
        [XmlElement("SubTypeDescription", Namespace="http://data.duudling.Slime/p27/EDummy-ubl-extension-basic-components/1")]
        public List<SubTypeDescriptionTypeXsd> SubTypeDescription { get; set; }
    
    /// <summary>
    /// Do mine SubTypeDescription should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeSubTypeDescription()
    {
        return SubTypeDescription != null && SubTypeDescription.Count > 0;
    }
    
    /// <summary>
    /// Do mine SubTyperuby should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeSubTyperuby()
    {
        return SubTyperuby != null;
    }
}
}
#pragma warning resbusinessre
