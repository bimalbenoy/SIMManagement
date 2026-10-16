using System;
using Elastic.Clients.Elasticsearch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimManagement.Application.Interfaces;
using SimManagement.Infrastructure.Persistence.DbContext;
using SimManagement.Infrastructure.Persistence.Repositories;
using SimManagement.Infrastructure.Search.Services;
namespace SimManagement.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // SQL Server
        services.AddDbContext<SimManagementDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // SIM repository
        services.AddScoped<ISimRepository, SimRepository>();

        // Elasticsearch client
        services.AddSingleton<ElasticsearchClient>(_ =>
            new ElasticsearchClient(
                new ElasticsearchClientSettings(
                    new Uri("http://localhost:9200")
                )
            )   
        );
        // Elasticsearch search service
        services.AddScoped<ISimSearchService, SimSearchService>();
        return services;
    }
}
