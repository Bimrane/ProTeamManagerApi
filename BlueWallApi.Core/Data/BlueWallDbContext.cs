using Microsoft.EntityFrameworkCore;
using BlueWallApi.Core.Models;

namespace BlueWallApi.Core.Data;

public class BlueWallDbContext : DbContext
{
    public BlueWallDbContext(DbContextOptions<BlueWallDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<Match> Matches => Set<Match>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration de la relation Team -> Players (Cascade delete)
        modelBuilder.Entity<Team>()
            .HasMany(t => t.Players)
            .WithOne(p => p.Team)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Team>()
            .HasMany(t => t.Matches)
            .WithOne(m => m.Team)
            .HasForeignKey(m => m.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}