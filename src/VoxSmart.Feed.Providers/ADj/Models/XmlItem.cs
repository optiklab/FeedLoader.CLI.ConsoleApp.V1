using System.Xml.Serialization;

namespace VoxSmart.Feed.Providers.ADj.Models
{
    public class XmlItem // : List<XmlChannel>
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("content:encoded")]
        public string ContentEncoded { get; set; }

        [XmlElement("pubDate")]
        public string PubDate { get; set; }

        [XmlElement("guid")]
        public string Guid { get; set; }

        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("wsj:articletype")]
        public string ArticleType { get; set; }
    }
}