namespace Highscores.Api.ViewModels.Highscores;

public class CreateHighscoreViewModel
{
    public string Player { get; private set; }
    public int Score { get; private set; }

    public CreateHighscoreViewModel(string player, int score)
    {
        Player = player;
        Score = score;
    }
}
