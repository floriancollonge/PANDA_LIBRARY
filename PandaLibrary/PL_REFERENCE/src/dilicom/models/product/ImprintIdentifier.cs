using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class ImprintIdentifier
    {
        
        [XmlElement("ImprintIDType")]
        public string ImprintIDType { get; set; }

        [XmlElement("IDValue")]
        public string IDValue { get; set; }

    }
}