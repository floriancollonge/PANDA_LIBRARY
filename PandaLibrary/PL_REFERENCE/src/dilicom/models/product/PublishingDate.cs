using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class PublishingDate
    {
        
        [XmlElement("PublishingDateRole")]
        public string PublishingDateRole { get; set; }

        [XmlElement("DateFormat")]
        public string DateFormat { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

    }
}