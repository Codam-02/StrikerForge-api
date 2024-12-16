using Microsoft.EntityFrameworkCore;

namespace StrikerForge.models;

public class StrikerForgeDbContext : DbContext
{
    public StrikerForgeDbContext(DbContextOptions<StrikerForgeDbContext> options) : base(options) { }

    public DbSet<SoccerTeam> Teams { get; set; } = null!;
    public DbSet<SoccerGame> SoccerGames { get; set; } = null!;

}