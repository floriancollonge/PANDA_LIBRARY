using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Territory
    {
        
        [XmlElement("RegionsIncluded")]
        public string RegionsIncluded { get; set; }
           
    }
}