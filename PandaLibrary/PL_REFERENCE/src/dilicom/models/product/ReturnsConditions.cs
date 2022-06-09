using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class ReturnsConditions
    {

        [XmlElement("ReturnsCodeType")]
        public string ReturnsCodeType { get; set; }

        [XmlElement("ReturnsCode")]
        public string ReturnsCode { get; set; }

    }
}