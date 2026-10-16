
namespace SimManagement.SyncWorker.Models;

public class SimReadModel
{
    public int Id { get; set; }

    public string SubscriptionId { get; set; } = string.Empty;

    public string Iccid { get; set; } = string.Empty;

    public string Msisdn { get; set; } = string.Empty;

    public string Imsi { get; set; } = string.Empty;

    public string? Eid { get; set; }

    // SQL Server stores SimState as int.
    public int SimState { get; set; }

    public DateTime CreatedDate { get; set; }

    // SQL Server marks UpdatedDate as NOT NULL.
    public DateTime UpdatedDate { get; set; }

    public string UpdatedBy { get; set; } = string.Empty;
}
