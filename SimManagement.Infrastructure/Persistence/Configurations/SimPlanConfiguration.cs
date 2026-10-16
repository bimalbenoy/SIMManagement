using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimManagement.Core.Entities;

namespace SimManagement.Infrastructure.Persistence.Configurations;

public class SimPlanConfiguration : IEntityTypeConfiguration<SimPlan>
{
    public void Configure(EntityTypeBuilder<SimPlan> builder)
    {
        builder.ToTable("SimPlans");

        // Composite primary key
        builder.HasKey(x => new
        {
            x.SimId,
            x.PlanId
        });

        // SimPlan → Sim
        builder.HasOne(x => x.Sim)
            .WithMany(x => x.SimPlans)
            .HasForeignKey(x => x.SimId)
            .OnDelete(DeleteBehavior.Cascade);

        // SimPlan → Plan
        builder.HasOne(x => x.Plan)
            .WithMany(x => x.SimPlans)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}