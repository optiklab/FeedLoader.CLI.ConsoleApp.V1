using System.Xml.Serialization;
using System.Xml;

namespace VoxSmart.Feed.Common
{
    public class FeedParser : IFeedParser
    {
        private static HttpClient _httpClient;

        public FeedParser(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> ParseXmlFromUrl<T>(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Uri cannot be null or empty", nameof(url));

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new ArgumentException("Uri is incorrect. Please provide absolute URI.");

            string xmlContent = await DownloadXmlFromUrl(url);
            T result = DeserializeXml<T>(xmlContent);

            return result;
        }

        private async Task<string> DownloadXmlFromUrl(string url)
        {
            using (HttpResponseMessage response = await _httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private T DeserializeXml<T>(string xmlContent)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = XmlReader.Create(new StringReader(xmlContent)))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
