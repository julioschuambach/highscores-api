using Highscores.Domain.Entities;
using Highscores.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Highscores.Infrastructure.Data;

public class HighscoresDbContext : DbContext
{
    private readonly string _connectionString = "Server = localhost, 1433; Database = HighscoresDb; User ID = sa; Password = 1q2w3e4r@#$;";
    public DbSet<Highscore> Highscores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfiguration(new HighscoreMapping());
}
