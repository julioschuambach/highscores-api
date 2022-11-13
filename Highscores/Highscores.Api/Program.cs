using Highscores.Api.ViewModels;
using Highscores.Domain.Entities;
using Highscores.Infrastructure.Data;
using Highscores.Infrastructure.Data.Repositories;
using Highscores.Infrastructure.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HighscoresDbContext>();
builder.Services.AddScoped<IHighscoreRepository, HighscoreRepository>();

var app = builder.Build();

app.MapPost("/highscores", async ([FromServices] IHighscoreRepository repository, [FromBody] HighscoreViewModel viewModel) =>
{
    Highscore newHighscore = new(viewModel.Player, viewModel.Score);

    try
    {
        var highscore = await repository.CreateHighscore(newHighscore);

        return Results.Created("/highscores", highscore);
    }
    catch
    {
        return Results.Problem("Falha interna no servidor!");
    }
});

app.MapGet("/highscores", async ([FromServices] IHighscoreRepository repository) =>
{
    try
    {
        var highscores = await repository.GetAllHighscores();

        return Results.Ok(highscores);
    }
    catch
    {
        return Results.Problem("Falha interna no servidor!");
    }
});

app.MapGet("/highscores/{player}", async ([FromServices] IHighscoreRepository repository, [FromRoute] string player) =>
{
    try
    {
        var highscores = await repository.GetHighscoresByPlayerName(player);

        return Results.Ok(highscores);
    }
    catch
    {
        return Results.Problem("Falha interna no servidor!");
    }
});

app.Run();
