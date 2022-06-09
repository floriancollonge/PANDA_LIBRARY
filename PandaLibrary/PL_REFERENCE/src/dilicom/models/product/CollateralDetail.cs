using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class CollateralDetail
    {

        [XmlElement("TextContent")]
        public TextContent TextContent { get; set; }

    }
}