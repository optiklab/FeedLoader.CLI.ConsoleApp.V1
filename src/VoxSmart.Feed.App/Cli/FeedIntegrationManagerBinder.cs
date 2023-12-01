using System.CommandLine.Binding;
using VoxSmart.Feed.Common;

namespace VoxSmart.Feed.App.Cli
{
    /// <summary>
    /// Class responsible for dependency injection of the short-lived applications, like command line apps.
    /// 
    /// In this class we specify which exactly provider has to be used with the requested endpoint.
    /// 
    /// So, provider is specified at compile time without any dynamic (as it was not required in the task).
    /// 
    /// https://learn.microsoft.com/en-us/dotnet/standard/commandline/dependency-injection
    /// </summary>
    public class FeedIntegrationManagerBinder : BinderBase<IFeedIntegrationManager>
    {
        protected override IFeedIntegrationManager GetBoundValue(BindingContext bindingContext) => GetTransactionsManager(bindingContext);

        IFeedIntegrationManager GetTransactionsManager(BindingContext bindingContext)
        {
            return new ADjFeedIntegrationManager(); // We specify which 3rd-party provider to use.
        }
    }
}
