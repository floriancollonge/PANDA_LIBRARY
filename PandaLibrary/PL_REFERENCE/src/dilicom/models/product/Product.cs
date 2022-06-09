using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Product
    {

        [XmlElement("RecordReference")]
        public string RecordReference { get; set; }

        [XmlElement("NotificationType")]
        public string NotificationType { get; set; }
        
        [XmlElement("ProductIdentifier")]
        public ProductIdentifier[] ProductIdentifier { get; set; }
        
        [XmlElement("Barcode")]
        public Barcode Barcode { get; set; }
        
        [XmlElement("DescriptiveDetail")]
        public DescriptiveDetail DescriptiveDetail { get; set; }
        
        [XmlElement("CollateralDetail")]
        public CollateralDetail CollateralDetail { get; set; }
        
        [XmlElement("PublishingDetail")]
        public PublishingDetail PublishingDetail { get; set; }
        
        [XmlElement("ProductSupply")]
        public ProductSupply ProductSupply { get; set; }
           
    }
}