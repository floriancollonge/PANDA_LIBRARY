using System.Xml.Serialization;

namespace Reference.Dilicom
{

    [XmlRoot("ONIXMessage")]
    public class OnixMessage
    {
        [XmlElement("Header")]
        public Header Header { get; set; }

        [XmlElement("Product")]
        public Product[] Products { get; set; }
    }
}