using System.Xml.Serialization;

namespace VoxSmart.Feed.Providers.ADj.Models
{
    public class XmlImage
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }
    }
}
