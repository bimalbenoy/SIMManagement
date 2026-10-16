using Microsoft.Extensions.DependencyInjection;

namespace SimManagement.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApiDI(
        this IServiceCollection services)
    {
        return services;
    }
}