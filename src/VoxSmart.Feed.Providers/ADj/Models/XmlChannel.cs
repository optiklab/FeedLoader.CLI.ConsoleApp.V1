using System.Xml.Serialization;

namespace VoxSmart.Feed.Providers.ADj.Models
{
    public class XmlChannel
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("atom:link")]
        public XmlAtomLink AtomLink { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("language")]
        public string Language { get; set; }

        [XmlElement("pubDate")]
        public string PubDate { get; set; }

        [XmlElement("lastBuildDate")]
        public string LastBuildDate { get; set; }

        [XmlElement("copyright")]
        public string Copyright { get; set; }

        [XmlElement("generator")]
        public string Generator { get; set; }

        [XmlElement("docs")]
        public string Docs { get; set; }

        [XmlElement("image")]
        public XmlImage Image { get; set; }

        [XmlElement("item")]
        public List<XmlItem> Items { get; set; }
    }
}
