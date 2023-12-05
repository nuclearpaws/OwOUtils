using Microsoft.Extensions.DependencyInjection;
using OwOUtils.Core.Services.Misc;
using OwOUtils.Infrastructure.Misc.Services;

namespace OwOUtils.Infrastructure.Misc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureMisc(
        this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }
}
