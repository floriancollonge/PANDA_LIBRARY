using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Contributor
    {
        
        [XmlElement("SequenceNumber")]
        public string SequenceNumber { get; set; }

        [XmlElement("ContributorRole")]
        public string ContributorRole { get; set; }

        [XmlElement("NamesBeforeKey")]
        public string NamesBeforeKey { get; set; }

        [XmlElement("KeyNames")]
        public string KeyNames { get; set; }

    }
}