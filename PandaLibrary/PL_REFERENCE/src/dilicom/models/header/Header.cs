using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Header
    {
        [XmlElement("Sender")]
        public Sender Sender { get; set; }

        [XmlElement("Addressee")]
        public Addressee Addressee { get; set; }

        [XmlElement("MessageNumber")]
        public string MessageNumber { get; set; }

        [XmlElement("SentDateTime")]
        public string SentDateTime { get; set; }
    }
}