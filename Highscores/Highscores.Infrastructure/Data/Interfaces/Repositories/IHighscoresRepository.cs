using Highscores.Domain.Entities;

namespace Highscores.Infrastructure.Data.Interfaces.Repositories;

public interface IHighscoresRepository
{
    Task<Highscore> CreateHighscore(Highscore highscore);
    Task<IEnumerable<Highscore>> GetAllHighscoresByPlayerName(string player);
    Task<IEnumerable<Highscore>> GetAllHighscores();
}
