using System.Xml.Serialization;

namespace VoxSmart.Feed.Providers.ADj.Models
{
    public class XmlAtomLink
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("rel")]
        public string Rel { get; set; }

        [XmlAttribute("href")]
        public string Href { get; set; }
    }
}
