namespace SimManagement.Core.Entities;

public class SimPlan
{
    public int SimId { get; set; }

    public int PlanId { get; set; }

    public Sim Sim { get; set; } = null!;

    public Plan Plan { get; set; } = null!;
}