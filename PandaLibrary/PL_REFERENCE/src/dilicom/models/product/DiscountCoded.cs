using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class DiscountCoded
    {

        [XmlElement("DiscountCodeType")]
        public string DiscountCodeType { get; set; }

        [XmlElement("DiscountCodeTypeName")]
        public string DiscountCodeTypeName { get; set; }

        [XmlElement("DiscountCode")]
        public string DiscountCode { get; set; }

    }
}