using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class ProductIdentifier
    {

        [XmlElement("ProductIDType")]
        public string ProductIDType { get; set; }

        [XmlElement("IDValue")]
        public string IDValue { get; set; }
        
    }
}