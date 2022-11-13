using Highscores.Domain.Entities;

namespace Highscores.Infrastructure.Data.Repositories.Interfaces;

public interface IHighscoreRepository
{
    Task<Highscore> CreateHighscore(Highscore highscore);
    Task<IEnumerable<Highscore>> GetAllHighscores();
    Task<IEnumerable<Highscore>> GetHighscoresByPlayerName(string player);
}
