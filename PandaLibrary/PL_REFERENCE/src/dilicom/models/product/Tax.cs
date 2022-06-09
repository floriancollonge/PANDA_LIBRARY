using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Tax
    {

        [XmlElement("TaxType")]
        public string TaxType { get; set; }

        [XmlElement("TaxRateCode")]
        public string TaxRateCode { get; set; }

        [XmlElement("TaxRatePercent")]
        public string TaxRatePercent { get; set; }

        [XmlElement("TaxableAmount")]
        public string TaxableAmount { get; set; }

        [XmlElement("TaxAmount")]
        public string TaxAmount { get; set; }

    }
}