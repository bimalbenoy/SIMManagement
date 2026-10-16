using SimManagement.Core.Enums;

namespace SimManagement.Core.Entities;

public class Plan
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public PlanType Type { get; set; }

    public ICollection<SimPlan> SimPlans { get; set; }
        = new List<SimPlan>();
}