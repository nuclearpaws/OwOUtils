using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OwOUtils.Cli.Commands;
using OwOUtils.Infrastructure.Security;
using OwOUtils.Shared.Services;

try
{
    var exitCode = await CreateCommandLineBuilder()
        .UseDefaults()
        .UseHost(
            _ => Host.CreateDefaultBuilder(),
            hostBuilder => hostBuilder
                .ConfigureHostConfiguration((hostConfigBuilder) =>
                {
                })
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder.AddJsonFile("appsettings.json", false, false);
                    configBuilder.AddJsonFile(
                        $"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
                        true,
                        false);
                })
                .ConfigureLogging((context, loggingBuilder) =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddDebug();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ICryptoRandomProvider, SystemCryptoRandomProvider>();
                })
                .UseConsoleLifetime())
        .Build()
        .InvokeAsync(args);
    return exitCode;
}
catch (Exception ex)
{
    Console.WriteLine("There was an unexpected error:");
    Console.WriteLine(ex);
    return 0xDEAD;
}

static CommandLineBuilder CreateCommandLineBuilder()
{
    var rootCommand = new RootCommand("OwO Utils")
    {
        GenerateCommand.GetCommand(),
    };

    var commandLineBuilder = new CommandLineBuilder(rootCommand);
    return commandLineBuilder;
}
