using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class TitleDetail
    {
        
        [XmlElement("TitleElement")]
        public TitleElement TitleElement { get; set; }

        [XmlElement("TitleType")]
        public string TitleType { get; set; }

    }
}