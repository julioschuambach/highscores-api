using Highscores.Domain.Entities;

namespace Highscores.Infrastructure.Data.Repositories.Interfaces;

public interface IHighscoreRepository
{
    Highscore CreateHighscore(Highscore highscore);
    IEnumerable<Highscore> GetAllHighscores();
    IEnumerable<Highscore> GetHighscoresByPlayerName(string player);
}
