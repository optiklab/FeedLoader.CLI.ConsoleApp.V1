using FluentAssertions;
using VoxSmart.Feed.App;
using VoxSmart.Feed.App.Cli;
using Xunit;

namespace VoxSmart.Feed.Tests
{
    public class ConsoleOutputHandlersTests
    {
        [Fact]
        public async Task Successfully_Loads_From_Valid_Uri()
        {
            string result = await ConsoleOutputHandlers.ReadUrlAsync(new Uri("https://feeds.a.dj.com/rss/RSSMarketsMain.xml"), new ADjFeedIntegrationManager());

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().Contain("Extracted 20 entities:");
        }

        [Fact]
        public async Task Shows_Error_For_Invalid_Uri()
        {
            var act = async () => await ConsoleOutputHandlers.ReadUrlAsync(new Uri("/rss/RSSMarketsMain.xml"), new ADjFeedIntegrationManager());

            var result = Assert.ThrowsAsync<ArgumentException>(act);

            result.Should().NotBeNull();
            result.Exception.Should().NotBeNull();
            result.Exception.Message.Should().NotBeNull();
            result.Exception.Message.Should().Contain("Invalid URI");
        }

        [Fact]
        public async Task Shows_Error_For_Empty_Uri()
        {
            var act = async () => await ConsoleOutputHandlers.ReadUrlAsync(new Uri(""), new ADjFeedIntegrationManager());

            var result = Assert.ThrowsAsync<ArgumentException>(act);

            result.Should().NotBeNull();
            result.Exception.Should().NotBeNull();
            result.Exception.Message.Should().NotBeNull();
            result.Exception.Message.Should().Contain("Invalid URI");
        }
    }
}