using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class DescriptiveDetail
    {
           
        [XmlElement("ProductComposition")]
        public string ProductComposition { get; set; }

        [XmlElement("ProductForm")]
        public string ProductForm { get; set; }

        [XmlElement("Measure")]
        public Measure Measure { get; set; }        

        [XmlElement("Collection")]
        public Collection Collection { get; set; }

        [XmlElement("TitleDetail")]
        public TitleDetail[] TitleDetail { get; set; }

        [XmlElement("Contributor")]
        public Contributor[] Contributor { get; set; }

        // [XmlElement("NoEdition")]
        // public NoEdition NoEdition { get; set; }

        [XmlElement("Language")]
        public Language[] Language { get; set; }

        [XmlElement("Extent")]
        public Extent Extent { get; set; }

        [XmlElement("Subject")]
        public Subject Subject { get; set; }

        [XmlElement("Audience")]
        public Audience Audience { get; set; }

    }
}