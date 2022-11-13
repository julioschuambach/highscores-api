namespace Highscores.Domain.Entities;

public class Highscore
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Player { get; private set; }
    public int Score { get; private set; }

    public Highscore() { }

    public Highscore(string player, int score)
    {
        Player = player;
        Score = score;
    }
}
