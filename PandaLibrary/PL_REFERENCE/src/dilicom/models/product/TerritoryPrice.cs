using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class TerritoryPrice
    {

        [XmlElement("CountriesIncluded")]
        public string CountriesIncluded { get; set; }

    }
}