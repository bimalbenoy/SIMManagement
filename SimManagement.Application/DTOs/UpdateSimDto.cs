
using System.ComponentModel.DataAnnotations;
using SimManagement.Core.Enums;

namespace SimManagement.Application.DTOs;

public class UpdateSimDto
{
    [Required]
    [StringLength(50)]
    public string SubscriptionId { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 20)]
    public string Iccid { get; set; } = string.Empty;

    [Required]
    [StringLength(15)]
    public string Msisdn { get; set; } = string.Empty;

    [Required]
    [StringLength(15)]
    public string Imsi { get; set; } = string.Empty;

    [StringLength(32)]
    public string? Eid { get; set; }

    [Required]
    [EnumDataType(typeof(SimState))]
    public SimState? SimState { get; set; }
}
