using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Product
    {
        [XmlElement("Header")]
        public Header Header { get; set; }

        [XmlElement("Product")]
        public Product[] Products { get; set; }
    }
}