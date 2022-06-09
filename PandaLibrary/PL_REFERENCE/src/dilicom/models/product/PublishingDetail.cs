using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class PublishingDetail
    {
        
        [XmlElement("Imprint")]
        public Imprint Imprint { get; set; }

        [XmlElement("CountryOfPublication")]
        public string CountryOfPublication { get; set; }

        [XmlElement("PublishingDate")]
        public PublishingDate PublishingDate { get; set; }

    }
}