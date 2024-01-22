using Microsoft.EntityFrameworkCore;
using MTA.Domain.Entities;

namespace MTA.Data.Contexts;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
    }
    public DbSet<TenantEntity> Tenants { get; set; }
    
}