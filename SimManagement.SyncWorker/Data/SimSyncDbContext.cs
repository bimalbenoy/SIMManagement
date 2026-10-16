
using Microsoft.EntityFrameworkCore;
using SimManagement.SyncWorker.Models;

namespace SimManagement.SyncWorker.Data;

public class SimSyncDbContext : DbContext
{
    public SimSyncDbContext(
        DbContextOptions<SimSyncDbContext> options)
        : base(options)
    {
    }

    public DbSet<SimReadModel> Sims => Set<SimReadModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SimReadModel>(entity =>
        {
            entity.ToTable("Sims");
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            entity.Property(s => s.SubscriptionId).IsRequired();
            entity.Property(s => s.Iccid).IsRequired();
            entity.Property(s => s.Msisdn).IsRequired();
            entity.Property(s => s.Imsi).IsRequired();
            entity.Property(s => s.SimState).IsRequired();
        });
    }
}
