using VoxSmart.Feed.Common.Model;

namespace VoxSmart.Feed.Common
{
    public interface IFeedIntegrationManager
    {
        Task<VoxSmartRss> LoadFromUriAsync(Uri uri);
    }
}
