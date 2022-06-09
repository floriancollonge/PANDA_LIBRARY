using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class TitleElement
    {
        
        [XmlElement("TitleElementLevel")]
        public string TitleElementLevel { get; set; }

        [XmlElement("TitleText")]
        public string TitleText { get; set; }

    }
}