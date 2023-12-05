using Microsoft.Extensions.DependencyInjection;
using OwOUtils.Core.Services.Security;
using OwOUtils.Infrastructure.Security.Services;

namespace OwOUtils.Infrastructure.Security;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureSecurity(
        this IServiceCollection services)
    {
        services.AddSingleton<IAesCryptographer, AesCryptographer>();
        services.AddSingleton<ICryptoRandomProvider, SystemCryptoRandomProvider>();

        return services;
    }
}
