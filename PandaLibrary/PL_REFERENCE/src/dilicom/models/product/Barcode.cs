using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Barcode
    {
           
        [XmlElement("BarcodeType")]
        public string BarcodeType { get; set; }

        [XmlElement("PositionOnProduct")]
        public string PositionOnProduct { get; set; }
        
    }
}