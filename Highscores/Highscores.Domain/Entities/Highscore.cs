using Highscores.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Highscores.Domain.Entities;

[Table("Highscores")]
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
