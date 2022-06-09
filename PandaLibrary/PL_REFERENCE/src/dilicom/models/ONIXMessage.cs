using System.Xml.Serialization;

namespace Reference.Dilicom
{

    [XmlRoot(ElementName = "ONIXMessage", Namespace = "http://www.editeur.org/onix/3.0/reference")]
    public class OnixMessage
    {
        [XmlElement("Header")]
        public Header Header { get; set; }

        [XmlElement("Product")]
        public Product[] Products { get; set; }
    }
}