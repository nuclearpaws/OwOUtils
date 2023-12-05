using Microsoft.Extensions.Configuration;

namespace OwOUtils.Cli;

internal static class ConfigurationProviderFactory
{
    public static IConfiguration Create()
    {
        var builder = new ConfigurationBuilder();

        const string configFileName = "appsettings";
        var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

        builder.AddJsonFile($"{configFileName}.json", false, false);
        builder.AddJsonFile($"{configFileName}.{environmentName}.json", true, false);

        var configuration = builder.Build();
        return configuration;
    }
}
