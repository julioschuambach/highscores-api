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

    public Highscore CreateHighscore(Highscore highscore)
    {
        _context.Highscores.Add(highscore);
        _context.SaveChanges();

        return highscore;
    }

    public IEnumerable<Highscore> GetAllHighscoresByPlayerName(string player)
    {
        var highscores = _context.Highscores
                                 .AsNoTracking()
                                 .Where(x => x.Player == player)
                                 .OrderByDescending(x => x.Score)
                                 .ToList();

        return highscores;
    }

    public IEnumerable<Highscore> GetAllHighscores()
    {
        var highscores = _context.Highscores
                                 .AsNoTracking()
                                 .OrderByDescending(x => x.Score)
                                 .ToList();

        return highscores;
    }
}
