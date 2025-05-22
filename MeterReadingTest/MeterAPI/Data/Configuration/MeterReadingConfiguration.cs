using MeterAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeterAPI.Data.Configuration;

public class MeterReadingConfiguration : IEntityTypeConfiguration<MeterReading>
{
    public void Configure(EntityTypeBuilder<MeterReading> builder)
    {
        // Table Name
        builder.ToTable("MeterReading");

        builder.HasNoKey();

        // Properties
        builder.Property(m => m.AccountId)
            .IsRequired();

        builder.Property(m => m.MeterReadingDateTime)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.Property(m => m.MeterReadValue)
            .IsRequired();
    }
}
