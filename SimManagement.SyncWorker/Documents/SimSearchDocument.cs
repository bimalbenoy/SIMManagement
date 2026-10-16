
namespace SimManagement.SyncWorker.Documents;

public class SimSearchDocument
{
    public int Id { get; set; }

    public string SubscriptionId { get; set; } = string.Empty;

    public string Iccid { get; set; } = string.Empty;

    public string Msisdn { get; set; } = string.Empty;

    public string Imsi { get; set; } = string.Empty;

    public string? Eid { get; set; }

    public string SimState { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
