using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Language
    {

        [XmlElement("LanguageRole")]
        public string LanguageRole { get; set; }

        [XmlElement("LanguageCode")]
        public string LanguageCode { get; set; }

    }
}