using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class TextContent
    {
        
        [XmlElement("TextType")]
        public string TextType { get; set; }

        [XmlElement("ContentAudience")]
        public string ContentAudience { get; set; }

        [XmlElement("Text")]
        public string Text { get; set; }

    }
}