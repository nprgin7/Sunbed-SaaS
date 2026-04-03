using Microsoft.EntityFrameworkCore;
using SunbedSaaS.Core.Entities;

namespace SunbedSaaS.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    // These represent the tables in your database
    public DbSet<Organization> Organizations { get; set; } = null!;
    public DbSet<Asset> Assets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Here is where we define the "Rules" (Fluent API)
        
        // 1. Organization Rules
        modelBuilder.Entity<Organization>(entity => {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        // 2. Asset Rules
        modelBuilder.Entity<Asset>(entity => {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            
            // Define the Relationship: One Organization -> Many Assets
            entity.HasOne(a => a.Organization)
                  .WithMany(o => o.Assets)
                  .HasForeignKey(a => a.OrganizationId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}