using Highscores.Domain.Entities;
using Highscores.Infrastructure.Data.Contexts;
using Highscores.Infrastructure.Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Highscores.Infrastructure.Data.Repositories;

public class HighscoresRepository : IHighscoresRepository
{
    private readonly HighscoresDbContext _context;

    public HighscoresRepository(HighscoresDbContext context)
        => _context = context;

    public async Task<Highscore> CreateHighscore(Highscore highscore)
    {
        await _context.Highscores.AddAsync(highscore);
        await _context.SaveChangesAsync();

        return highscore;
    }

    public async Task<IEnumerable<Highscore>> GetAllHighscoresByPlayerName(string player)
    {
        var highscores = await _context.Highscores
                                       .AsNoTracking()
                                       .Where(x => x.Player == player)
                                       .OrderByDescending(x => x.Score)
                                       .ToListAsync();

        return highscores;
    }

    public async Task<IEnumerable<Highscore>> GetAllHighscores()
    {
        var highscores = await _context.Highscores
                                       .AsNoTracking()
                                       .OrderByDescending(x => x.Score)
                                       .ToListAsync();

        return highscores;
    }
}
