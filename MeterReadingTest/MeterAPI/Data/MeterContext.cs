using MeterAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Data;

public class MeterContext : DbContext
{
    public MeterContext(DbContextOptions<MeterContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; } = null!;
}