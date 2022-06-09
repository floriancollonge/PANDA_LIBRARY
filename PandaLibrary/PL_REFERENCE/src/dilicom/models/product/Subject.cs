using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Subject
    {

        [XmlElement("SubjectSchemeIdentifier")]
        public string SubjectSchemeIdentifier { get; set; }

        [XmlElement("SubjectCode")]
        public string SubjectCode { get; set; }

    }
}