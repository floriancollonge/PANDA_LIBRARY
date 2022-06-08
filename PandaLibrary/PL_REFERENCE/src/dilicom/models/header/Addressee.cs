using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Addressee
    {
        [XmlElement("AddresseeIdentifier")]
        public AddresseeIdentifier AddresseeIdentifier { get; set; }

        [XmlElement("AddresseeName")]
        public string AddresseeName { get; set; }

    }
}