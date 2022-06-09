using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Audience
    {

        [XmlElement("AudienceCodeType")]
        public string AudienceCodeType { get; set; }

        [XmlElement("AudienceCodeValue")]
        public string AudienceCodeValue { get; set; }

    }
}