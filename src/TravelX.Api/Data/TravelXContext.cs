using Microsoft.EntityFrameworkCore;
using TravelX.Shared.Models;

namespace TravelX.Api.Data;

public class TravelXContext : DbContext
{
    public TravelXContext(DbContextOptions<TravelXContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<HotelOwnerProfile> HotelOwnerProfiles { get; set; } = null!;
    public DbSet<InvestorProfile> InvestorProfiles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasOne(u => u.HotelOwnerProfile)
            .WithOne(h => h.User)
            .HasForeignKey<HotelOwnerProfile>(h => h.UserId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.InvestorProfile)
            .WithOne(i => i.User)
            .HasForeignKey<InvestorProfile>(i => i.UserId);
    }
}