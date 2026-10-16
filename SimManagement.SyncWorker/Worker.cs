
using SimManagement.SyncWorker.Data.Repositories;
using SimManagement.SyncWorker.Mapping;
using SimManagement.SyncWorker.Search;

namespace SimManagement.SyncWorker;

public class Worker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<Worker> _logger;
    private readonly ElasticsearchWriter _elasticsearchWriter;

    public Worker(
        IServiceScopeFactory scopeFactory,
        ILogger<Worker> logger,
        ElasticsearchWriter elasticsearchWriter)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _elasticsearchWriter = elasticsearchWriter;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        using var scope = _scopeFactory.CreateScope();

        var repository = scope.ServiceProvider
            .GetRequiredService<SimSyncRepository>();

        var sim = await repository.GetByIdAsync(1);

        if (sim is null)
        {
            _logger.LogWarning("SIM ID 1 was not found in SQL Server.");
            return;
        }

        var document = SimSearchDocumentMapper.ToDocument(sim);

        await _elasticsearchWriter.IndexSimAsync(
            document,
            stoppingToken);

        _logger.LogInformation(
            "SIM {SimId} was synchronized to Elasticsearch.",
            sim.Id);
    }
}
