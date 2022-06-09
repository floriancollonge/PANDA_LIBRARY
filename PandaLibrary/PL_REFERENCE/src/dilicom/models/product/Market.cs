using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Market
    {
        
        [XmlElement("Territory")]
        public Territory Territory { get; set; }
           
    }
}