using Microsoft.EntityFrameworkCore;
using SimManagement.Core.Entities;

namespace SimManagement.Infrastructure.Persistence.DbContext;

public class SimManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public SimManagementDbContext(
        DbContextOptions<SimManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<Sim> Sims { get; set; }

    public DbSet<Plan> Plans { get; set; }

    public DbSet<SimPlan> SimPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(SimManagementDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}