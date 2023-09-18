using Highscores.Domain.Entities;

namespace Highscores.Infrastructure.Data.Interfaces.Repositories;

public interface IHighscoresRepository
{
    Highscore CreateHighscore(Highscore highscore);
    IEnumerable<Highscore> GetAllHighscoresByPlayerName(string player);
    IEnumerable<Highscore> GetAllHighscores();
}
