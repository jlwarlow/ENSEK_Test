using MeterAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Data;

public interface IMeterContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<MeterReading> MeterReadings { get; set; }
    public int SaveChanges();
}
