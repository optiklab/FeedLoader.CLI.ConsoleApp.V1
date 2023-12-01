using FluentAssertions;
using VoxSmart.Feed.App;
using Xunit;

namespace VoxSmart.Feed.Tests;

public class FeedIntegrationManagerTests
{
    [Fact]
    public async Task Successfully_Loads_From_Valid_Uri()
    {
        var manager = new ADjFeedIntegrationManager();

        var result = await manager.LoadFromUriAsync(new Uri("https://feeds.a.dj.com/rss/RSSMarketsMain.xml"));

        result.Should().NotBeNull();
        result.Entities.Should().NotBeNull();

        Assert.Equal(20, result.Entities.Count);

        result.Entities[0].Title.Should().NotBeNull();
        result.Entities[0].Title.Should().NotBeEmpty();

        result.Entities[1].Title.Should().NotBeNull();
        result.Entities[1].Title.Should().NotBeEmpty();
    }

    [Fact]
    public void Gracefully_Fails_On_Invalid_Uri()
    {
        var manager = new ADjFeedIntegrationManager();

        var act = async () => await manager.LoadFromUriAsync(new Uri("/rss/RSSMarketsMain.xml"));

        var result = Assert.ThrowsAsync<ArgumentException>(act);

        result.Should().NotBeNull();
        result.Exception.Should().NotBeNull();
        result.Exception.Message.Should().NotBeNull();
        result.Exception.Message.Should().Contain("Invalid URI");
    }
}
