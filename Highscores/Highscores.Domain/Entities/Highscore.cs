using Highscores.Domain.Entities.Base;

namespace Highscores.Domain.Entities;

public class Highscore : EntityBase
{
    public string Player { get; private set; }
    public int Score { get; private set; }

    public Highscore(string player, int score)
    {
        Player = player;
        Score = score;
    }
}
