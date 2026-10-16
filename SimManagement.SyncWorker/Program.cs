using Elastic.Clients.Elasticsearch;
using Microsoft.EntityFrameworkCore;
using SimManagement.SyncWorker;
using SimManagement.SyncWorker.Data;
using SimManagement.SyncWorker.Data.Repositories;
using SimManagement.SyncWorker.Search;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<SimSyncDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<SimSyncRepository>();

var settings = new ElasticsearchClientSettings(
    new Uri("http://localhost:9200"))
    .DefaultIndex("sim-management-v1");

builder.Services.AddSingleton(
    new ElasticsearchClient(settings));

builder.Services.AddSingleton<ElasticsearchWriter>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();