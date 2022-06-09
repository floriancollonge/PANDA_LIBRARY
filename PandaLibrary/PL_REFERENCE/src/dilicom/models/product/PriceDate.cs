using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class PriceDate
    {

        [XmlElement("PriceDateRole")]
        public string PriceDateRole { get; set; }

        [XmlElement("DateFormat")]
        public string DateFormat { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

    }
}