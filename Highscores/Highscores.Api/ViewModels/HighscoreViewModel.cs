using System.ComponentModel.DataAnnotations;

namespace Highscores.Api.ViewModels;

public class HighscoreViewModel
{
    [Required]
    [StringLength(15)]
    public string Player { get; set; }

    [Required]
    public int Score { get; set; }
}
