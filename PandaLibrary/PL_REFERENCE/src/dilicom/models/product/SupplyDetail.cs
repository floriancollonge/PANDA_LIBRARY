using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class SupplyDetail
    {

        [XmlElement("Supplier")]
        public Supplier Supplier { get; set; }

        [XmlElement("ProductAvailability")]
        public string ProductAvailability { get; set; }

        [XmlElement("ReturnsConditions")]
        public ReturnsConditions ReturnsConditions { get; set; }

        [XmlElement("Price")]
        public Price[] Price { get; set; }

    }
}