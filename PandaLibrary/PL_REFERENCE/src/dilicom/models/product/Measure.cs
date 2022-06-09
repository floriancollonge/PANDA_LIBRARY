using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Measure
    {
        
        [XmlElement("MeasureType")]
        public string MeasureType { get; set; }

        [XmlElement("Measurement")]
        public string Measurement { get; set; }

        [XmlElement("MeasureUnitCode")]
        public string MeasureUnitCode { get; set; }

    }
}