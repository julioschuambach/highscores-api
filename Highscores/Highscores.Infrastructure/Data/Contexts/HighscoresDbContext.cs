using Highscores.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Highscores.Infrastructure.Data.Contexts;

public class HighscoresDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Highscore> Highscores { get; set; }

    public HighscoresDbContext(IConfiguration configuration)
        => _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
}
