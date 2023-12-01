using System.CommandLine;
using VoxSmart.Feed.Common;

namespace VoxSmart.Feed.App.Cli
{
    /// <summary>
    /// Responsible for Console Input and Output.
    /// </summary>
    public static class CliRoot
    {
        /// <summary>
        /// Initializes commands patterns using dotnet functionality
        /// https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial
        /// https://learn.microsoft.com/en-us/dotnet/standard/commandline/
        /// 
        /// NOTE: In case it would have much more commands, I would split it to classes and implemented some Reflection-based mechanism to automatically register commands.
        /// </summary>
        public static RootCommand Initialize()
        {
            var rootCommand = new RootCommand("VoxSmart CLI app to work with Financial feeds.");

            var urlFeedCommand = new Command("--read-url-feed", "Reads financial entity names from the feed XML available via specified URL.");
            var urlFeedAgrument = new Argument<Uri>("url", "URI to download.");
            urlFeedCommand.AddArgument(urlFeedAgrument);
            urlFeedCommand.SetHandler(async (url, feedIntegrationManager) => await ReadUrlAsync(url, feedIntegrationManager), urlFeedAgrument, new FeedIntegrationManagerBinder());

            rootCommand.AddCommand(urlFeedCommand);

            return rootCommand;
        }

        static async Task ReadUrlAsync(Uri url, IFeedIntegrationManager feedIntegrationManager)
        {
            Console.WriteLine(await ConsoleOutputHandlers.ReadUrlAsync(url, feedIntegrationManager));
        }
    }
}
