using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class AddresseeIdentifier
    {
        [XmlElement("AddresseeIDType")]
        public string AddresseeIDType { get; set; }

        [XmlElement("IDValue")]
        public string IDValue { get; set; }

    }
}