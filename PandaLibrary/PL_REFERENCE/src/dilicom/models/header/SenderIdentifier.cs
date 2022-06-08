using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class SenderIdentifier
    {
        [XmlElement("SenderIDType")]
        public string SenderIDType { get; set; }

        [XmlElement("IDValue")]
        public string IDValue { get; set; }

    }
}