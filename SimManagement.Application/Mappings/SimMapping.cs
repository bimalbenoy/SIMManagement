
using SimManagement.Application.DTOs;
using SimManagement.Core.Entities;

namespace SimManagement.Application.Mappings;

public static class SimMapping
{
    public static Sim ToEntity(CreateSimDto dto)
    {
        return new Sim
        {
            SubscriptionId = dto.SubscriptionId,
            Iccid = dto.Iccid,
            Msisdn = dto.Msisdn,
            Imsi = dto.Imsi,
            Eid = dto.Eid,
            SimState = dto.SimState!.Value,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            UpdatedBy = "system"
        };
    }

    public static void UpdateEntity(Sim sim, UpdateSimDto dto)
    {
        sim.SubscriptionId = dto.SubscriptionId;
        sim.Iccid = dto.Iccid;
        sim.Msisdn = dto.Msisdn;
        sim.Imsi = dto.Imsi;
        sim.Eid = dto.Eid;
        sim.SimState = dto.SimState!.Value;
        sim.UpdatedDate = DateTime.UtcNow;
        sim.UpdatedBy = "system";
    }

    public static SimResponseDto ToResponseDto(Sim sim)
    {
        return new SimResponseDto
        {
            Id = sim.Id,
            SubscriptionId = sim.SubscriptionId,
            Iccid = sim.Iccid,
            Msisdn = sim.Msisdn,
            Imsi = sim.Imsi,
            Eid = sim.Eid,
            SimState = sim.SimState,
            CreatedDate = sim.CreatedDate,
            UpdatedDate = sim.UpdatedDate,
            UpdatedBy = sim.UpdatedBy
        };
    }
}
