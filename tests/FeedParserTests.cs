using Xunit;
using VoxSmart.Feed.Common;
using VoxSmart.Feed.Providers.ADj.Models;
using FluentAssertions;

namespace VoxSmart.Feed.Tests
{
    public class FeedParserTests
    {
        [Fact]
        public async Task ParseXmlFromUrl_ValidUrl_ReturnsParsedObject()
        {
            // Define a sample XML response and expected object
            string sampleXml = "<rss><channel><title>WSJ.com: Markets</title><link>http://online.wsj.com</link>\t<description>Markets</description><item><title>1</title><description>description</description></item><item><title>2</title><description>description</description></item></channel></rss>";

            // Arrange
            var httpClientMock = HttpClientMock.GetHttpClientMock(sampleXml);
            var xmlParser = new FeedParser(httpClientMock);

            // Act
            var result = await xmlParser.ParseXmlFromUrl<XmlADjRss>("http://example.com/sample.xml");

            // Assert
            result.Should().NotBeNull();
            result.Channel.Should().NotBeNull();
            result.Channel.Items.Should().NotBeNull();

            Assert.Equal(2, result.Channel.Items.Count);
            Assert.Equal("1", result.Channel.Items[0].Title);
            Assert.Equal("2", result.Channel.Items[1].Title);
        }

        [Fact]
        public async Task ParseXmlFromUrl_EmptyUrl_ThrowsException()
        {
            // Arrange
            var httpClientMock = HttpClientMock.GetHttpClientMock("");
            var xmlParser = new FeedParser(httpClientMock);

            // Act
            var act = async () => await xmlParser.ParseXmlFromUrl<XmlADjRss>("");

            var result = Assert.ThrowsAsync<ArgumentException>(act);

            // Assert
            result.Should().NotBeNull();
            result.Result.Message.Should().NotBeNull();
            result.Result.Message.Should().Contain("Uri cannot be null or empty");
        }

        [Fact]
        public async Task ParseXmlFromUrl_InvalidUrl_ThrowsException()
        {
            // Arrange
            var httpClientMock = HttpClientMock.GetHttpClientMock("");
            var xmlParser = new FeedParser(httpClientMock);

            // Act
            var act = async () => await xmlParser.ParseXmlFromUrl<XmlADjRss>("http://");

            var result = Assert.ThrowsAsync<ArgumentException>(act);

            // Assert
            result.Should().NotBeNull();
            result.Result.Message.Should().NotBeNull();
            result.Result.Message.Should().Contain("Uri is incorrect. Please provide absolute URI.");
        }
    }
}