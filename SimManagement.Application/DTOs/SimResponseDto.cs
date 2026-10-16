
using SimManagement.Core.Enums;

namespace SimManagement.Application.DTOs;

public class SimResponseDto
{
    public int Id { get; set; }

    public string SubscriptionId { get; set; } = string.Empty;

    public string Iccid { get; set; } = string.Empty;

    public string Msisdn { get; set; } = string.Empty;

    public string Imsi { get; set; } = string.Empty;

    public string? Eid { get; set; }

    public SimState SimState { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string UpdatedBy { get; set; } = string.Empty;
}
