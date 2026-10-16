using Microsoft.Extensions.DependencyInjection;
using SimManagement.Application.Interfaces;
using SimManagement.Application.Services;

namespace SimManagement.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDI(
        this IServiceCollection services)
    {
        services.AddScoped<ISimService, SimService>();
        return services;
    }
}