using Highscores.Api.ViewModels.Highscores;
using Highscores.Domain.Entities;
using Highscores.Infrastructure.Data.Contexts;
using Highscores.Infrastructure.Data.Interfaces.Repositories;
using Highscores.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Highscores.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<IHighscoresRepository, HighscoresRepository>();
        builder.Services.AddDbContext<HighscoresDbContext>();

        var app = builder.Build();
        MapEndpoints(app);

        app.Run();
    }

    private static void MapEndpoints(WebApplication app)
    {
        app.MapPost("/highscores", async ([FromServices] IHighscoresRepository repository, [FromBody] CreateHighscoreViewModel createViewModel) =>
        {
            Highscore highscore = new(createViewModel.Player, createViewModel.Score);

            try
            {
                return Results.Created($"/highscores/{highscore.Id}", await repository.CreateHighscore(highscore));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });

        app.MapGet("/highscores/{player}", async ([FromServices] IHighscoresRepository repository, [FromRoute] string player) =>
        {
            try
            {
                return Results.Ok(await repository.GetAllHighscoresByPlayerName(player));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });

        app.MapGet("/highscores", async ([FromServices] IHighscoresRepository repository) =>
        {
            try
            {
                return Results.Ok(await repository.GetAllHighscores());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
    }
}
