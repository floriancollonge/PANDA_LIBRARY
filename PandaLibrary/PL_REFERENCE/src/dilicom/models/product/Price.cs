using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Price
    {

        [XmlElement("PriceType")]
        public string PriceType { get; set; }

        [XmlElement("DiscountCoded")]
        public DiscountCoded DiscountCoded { get; set; }

        [XmlElement("PriceStatus")]
        public string PriceStatus { get; set; }

        [XmlElement("PriceAmount")]
        public string PriceAmount { get; set; }

        [XmlElement("Tax")]
        public Tax Tax { get; set; }

        [XmlElement("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [XmlElement("Territory")]
        public TerritoryPrice Territory { get; set; }

        [XmlElement("PriceDate")]
        public PriceDate PriceDate { get; set; }

    }
}