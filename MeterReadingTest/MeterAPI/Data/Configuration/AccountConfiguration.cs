using MeterAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeterAPI.Data.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // Table Name
        builder.ToTable("Account");

        // Primary Key
        builder.HasKey(a => a.AccountId);

        // Properties
        builder.Property(a => a.AccountId)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.FirstName)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(100);

        builder.Property(a => a.LastName)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(100);
    }
}