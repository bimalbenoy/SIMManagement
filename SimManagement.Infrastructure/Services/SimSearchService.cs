
using Elastic.Clients.Elasticsearch;
using SimManagement.Application.Interfaces;
using SimManagement.Core.Entities;
using SimManagement.Infrastructure.Search.Documents;

namespace SimManagement.Infrastructure.Search.Services;

public class SimSearchService : ISimSearchService
{
    private readonly ElasticsearchClient _client;

    public SimSearchService(ElasticsearchClient client)
    {
        _client = client;
    }

    public async Task IndexSimAsync(Sim sim)
    {
        var document = SimSearchDocumentMapping.ToDocument(sim);

        var response = await _client.IndexAsync(
            document,
            "sim-management-v1"
        );

        if (!response.IsValidResponse)
        {
            throw new InvalidOperationException(
                $"Failed to index SIM with ID {sim.Id} in Elasticsearch."
            );
        }
    }
}
