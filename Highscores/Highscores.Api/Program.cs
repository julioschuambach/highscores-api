using Highscores.Api.ViewModels.Highscores;
using Highscores.Domain.Entities;
using Highscores.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Highscores.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<HighscoresDbContext>();

        var app = builder.Build();
        MapEndpoints(app);

        app.Run();
    }

    private static void MapEndpoints(WebApplication app)
    {
        app.MapPost("/highscores", ([FromServices] HighscoresDbContext context, [FromBody] CreateHighscoreViewModel createViewModel) =>
        {
            Highscore highscore = new(createViewModel.Player, createViewModel.Score);

            try
            {
                context.Highscores.Add(highscore);
                context.SaveChanges();
                return Results.Created($"/highscores/{highscore.Id}", highscore);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });

        app.MapGet("/highscores/{player}", ([FromServices] HighscoresDbContext context, [FromRoute] string player) =>
        {
            try
            {
                var highscores = context.Highscores
                                        .AsNoTracking()
                                        .Where(x => x.Player == player)
                                        .OrderByDescending(x => x.Score)
                                        .ToList();

                return Results.Ok(highscores);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });

        app.MapGet("/highscores", ([FromServices] HighscoresDbContext context) =>
        {
            try
            {
                var highscores = context.Highscores
                                        .AsNoTracking()
                                        .OrderByDescending(x => x.Score)
                                        .ToList();

                return Results.Ok(highscores);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
    }
}
