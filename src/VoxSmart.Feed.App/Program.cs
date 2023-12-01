using System.CommandLine;
using VoxSmart.Feed.App.Cli;

class Program
{
    static async Task<int> Main(string[] args)
    {
        return await CliRoot.Initialize().InvokeAsync(args);
    }
}