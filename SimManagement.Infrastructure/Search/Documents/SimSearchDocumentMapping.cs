
using SimManagement.Core.Entities;

namespace SimManagement.Infrastructure.Search.Documents;

public static class SimSearchDocumentMapping
{
    public static SimSearchDocument ToDocument(Sim sim)
    {
        return new SimSearchDocument
        {
            Id = sim.Id,
            SubscriptionId = sim.SubscriptionId,
            Iccid = sim.Iccid,
            Msisdn = sim.Msisdn,
            Imsi = sim.Imsi,
            Eid = sim.Eid,
            SimState = sim.SimState.ToString(),
            CreatedDate = sim.CreatedDate,
            UpdatedDate = sim.UpdatedDate
        };
    }
}
