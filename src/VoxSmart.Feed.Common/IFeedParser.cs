namespace VoxSmart.Feed.Common
{
    public interface IFeedParser
    {
        Task<T> ParseXmlFromUrl<T>(string url);
    }
}
