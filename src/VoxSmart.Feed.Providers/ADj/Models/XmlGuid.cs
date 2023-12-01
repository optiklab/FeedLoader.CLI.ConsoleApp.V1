using System.Xml.Serialization;

namespace VoxSmart.Feed.Providers.ADj.Models
{
    public class XmlGuid
    {
        [XmlAttribute("isPermaLink")]
        public bool isPermaLink { get; set; }

        public string Value { get; set; }
    }
}
