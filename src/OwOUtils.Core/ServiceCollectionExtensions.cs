using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace OwOUtils.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(
        this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(assembly);

        return services;
    }
}
