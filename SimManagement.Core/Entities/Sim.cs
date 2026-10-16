using SimManagement.Core.Enums;

namespace SimManagement.Core.Entities;

public class Sim
{
    public int Id { get; set; }

    public string SubscriptionId { get; set; } = string.Empty;

    // 20-digit SIM identifier
    public string Iccid { get; set; } = string.Empty;

    // Mobile number - can change
    public string Msisdn { get; set; } = string.Empty;

    // 13-digit subscriber identity
    public string Imsi { get; set; } = string.Empty;

    // eSIM identifier - nullable for physical SIM
    public string? Eid { get; set; }

    public SimState SimState { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string UpdatedBy { get; set; } = string.Empty;

    // Plans associated with this SIM
    public ICollection<SimPlan> SimPlans { get; set; }
        = new List<SimPlan>();
}