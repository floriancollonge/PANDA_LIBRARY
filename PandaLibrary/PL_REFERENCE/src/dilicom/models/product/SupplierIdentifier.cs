using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class SupplierIdentifier
    {

        [XmlElement("SupplierIDType")]
        public string SupplierIDType { get; set; }

        [XmlElement("IDValue")]
        public string IDValue { get; set; }

    }
}