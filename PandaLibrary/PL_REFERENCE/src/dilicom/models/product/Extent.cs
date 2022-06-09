using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Extent
    {

        [XmlElement("ExtentType")]
        public string ExtentType { get; set; }

        [XmlElement("ExtentValue")]
        public string ExtentValue { get; set; }

        [XmlElement("ExtentUnit")]
        public string ExtentUnit { get; set; }

    }
}