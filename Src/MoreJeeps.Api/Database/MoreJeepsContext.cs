using MoreJeeps.Api.Contracts.Data;
using Microsoft.EntityFrameworkCore;

namespace MoreJeeps.Api.Database;

public class MoreJeepsContext : DbContext
{
    public DbSet<SightingEntity> Sightings { get; set; } = default!;
    public DbSet<GameEntity> Games { get; set; } = default!;

    public MoreJeepsContext(DbContextOptions<MoreJeepsContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameEntity>()
            .ToTable("Games");

        modelBuilder.Entity<SightingEntity>()
            .ToTable("Sightings")
            .HasOne<GameEntity>(s => s.Game)
            .WithMany(g => g.SightingEntities)
            .HasForeignKey(s => s.GameId);
    }
}