
using SimManagement.SyncWorker.Documents;
using SimManagement.SyncWorker.Models;

namespace SimManagement.SyncWorker.Mapping;

public static class SimSearchDocumentMapper
{
    public static SimSearchDocument ToDocument(SimReadModel sim)
    {
        return new SimSearchDocument
        {
            Id = sim.Id,
            SubscriptionId = sim.SubscriptionId,
            Iccid = sim.Iccid,
            Msisdn = sim.Msisdn,
            Imsi = sim.Imsi,
            Eid = sim.Eid,

            // SQL stores SimState as an integer.
            // Elasticsearch expects a keyword/string.
            SimState = sim.SimState switch
            {
                0 => "Stock",
                1 => "Active",
                2 => "Deactivated",
                _ => "Unknown"
            },

            CreatedDate = sim.CreatedDate,
            UpdatedDate = sim.UpdatedDate
        };
    }
}
