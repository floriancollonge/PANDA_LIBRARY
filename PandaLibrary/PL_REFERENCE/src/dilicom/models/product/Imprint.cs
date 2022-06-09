using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Imprint
    {
        
        [XmlElement("ImprintIdentifier")]
        public ImprintIdentifier ImprintIdentifier { get; set; }

        [XmlElement("ImprintName")]
        public string ImprintName { get; set; }

    }
}