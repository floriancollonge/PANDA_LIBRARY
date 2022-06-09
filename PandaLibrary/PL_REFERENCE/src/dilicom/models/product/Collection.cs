using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Collection
    {
        
        [XmlElement("TitleDetail")]
        public TitleDetail TitleDetail { get; set; }

        [XmlElement("CollectionType")]
        public string CollectionType { get; set; }

    }
}