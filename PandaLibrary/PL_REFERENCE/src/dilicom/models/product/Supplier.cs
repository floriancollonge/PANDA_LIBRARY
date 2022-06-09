using System.Xml.Serialization;

namespace Reference.Dilicom
{

    public class Supplier
    {

        [XmlElement("SupplierRole")]
        public string SupplierRole { get; set; }

        [XmlElement("SupplierIdentifier")]
        public SupplierIdentifier SupplierIdentifier { get; set; }

        [XmlElement("SupplierName")]
        public string SupplierName { get; set; }

    }
}