using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimManagement.Core.Entities;

namespace SimManagement.Infrastructure.Persistence.Configurations;

public class SimConfiguration : IEntityTypeConfiguration<Sim>
{
    public void Configure(EntityTypeBuilder<Sim> builder)
    {
        builder.ToTable("Sims");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.SubscriptionId)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Iccid)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Msisdn)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(x => x.Imsi)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(x => x.Eid)
            .HasMaxLength(32);

        builder.Property(x => x.SimState)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedDate)
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .IsRequired()
            .HasMaxLength(100);
    }
}