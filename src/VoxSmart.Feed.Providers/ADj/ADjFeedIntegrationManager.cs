using VoxSmart.Feed.Common;
using VoxSmart.Feed.Common.Model;
using VoxSmart.Feed.Providers.ADj.Models;

namespace VoxSmart.Feed.App
{
    public class ADjFeedIntegrationManager : IFeedIntegrationManager
    {
        private static HttpClient _httpClient = new HttpClient(); // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/

        /// <summary>
        /// Downloads specified XML file and parses it.
        /// </summary>
        public async Task<VoxSmartRss> LoadFromUriAsync(Uri uri)
        {
            VoxSmartRss result = null;

            var xmlParser = new FeedParser(_httpClient);

            try
            {
                XmlADjRss response = await xmlParser.ParseXmlFromUrl<XmlADjRss>(uri.ToString());

                result = MapFromThirdParty(response);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        private VoxSmartRss MapFromThirdParty(XmlADjRss thirdPartyModel)
        {
            var yourDomainModel = new VoxSmartRss();

            if (thirdPartyModel != null && 
                thirdPartyModel.Channel != null && 
                thirdPartyModel.Channel.Items != null)
            {
                foreach (var item in thirdPartyModel.Channel.Items)
                {
                    yourDomainModel.Entities.Add(new VoxSmartEntity
                    {
                        Title = item.Title,
                        Link = item.Link,
                        Description = item.Description

                        // TODO Add more if needed.

                    });
                }
            }

            return yourDomainModel;
        }
    }
}
