using System.Xml.Serialization;

namespace VoxSmart.Feed.Providers.ADj.Models
{
    [XmlRoot("rss")]
    public class XmlADjRss
    {
        [XmlElement("channel")]
        public XmlChannel Channel { get; set; }
    }
}
