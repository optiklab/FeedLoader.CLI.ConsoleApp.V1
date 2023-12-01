using System.Xml.Serialization;

namespace VoxSmart.Feed.Providers.ADj.Models
{
    public class XmlCategory
    {
        [XmlAttribute("domain")]
        public string Domain { get; set; }

        public string Value { get; set; }
    }
}
