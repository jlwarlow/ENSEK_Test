using MeterAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeterAPI.Data;

public class MeterContext : DbContext
{
    public MeterContext(DbContextOptions<MeterContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Account> Accounts { get; set; } = null!;

    public DbSet<MeterReading> MeterReadings { get; set; } = null!;
}