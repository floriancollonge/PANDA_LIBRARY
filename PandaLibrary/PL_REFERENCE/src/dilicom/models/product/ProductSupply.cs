using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class ProductSupply
    {

        [XmlElement("Market")]
        public Market Market { get; set; }

        [XmlElement("SupplyDetail")]
        public SupplyDetail SupplyDetail { get; set; }

    }
}