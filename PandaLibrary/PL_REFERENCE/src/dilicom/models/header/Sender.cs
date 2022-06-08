using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Sender
    {
        [XmlElement("SenderIdentifier")]
        public SenderIdentifier SenderIdentifier { get; set; }

        [XmlElement("SenderName")]
        public string SenderName { get; set; }

        [XmlElement("EmailAddress")]
        public string EmailAddress { get; set; }

    }
}