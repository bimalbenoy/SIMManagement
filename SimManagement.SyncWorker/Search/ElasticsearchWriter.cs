
using Elastic.Clients.Elasticsearch;
using SimManagement.SyncWorker.Documents;

namespace SimManagement.SyncWorker.Search;

public class ElasticsearchWriter
{
    private readonly ElasticsearchClient _client;

    public ElasticsearchWriter(ElasticsearchClient client)
    {
        _client = client;
    }

    public async Task IndexSimAsync(
    SimSearchDocument document,
    CancellationToken cancellationToken = default)
    {
        var response = await _client.IndexAsync(
            document,
            request => request
                .Index("sim-management-v1")
                .Id(document.Id.ToString()),
            cancellationToken);

        if (!response.IsValidResponse)
        {
            throw new InvalidOperationException(
                $"Failed to index SIM {document.Id}: " +
                response.DebugInformation);
        }
    }
}
