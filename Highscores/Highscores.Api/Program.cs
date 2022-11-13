using Highscores.Api.ViewModels;
using Highscores.Domain.Entities;
using Highscores.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HighscoresDbContext>();

var app = builder.Build();

app.MapPost("/highscores", ([FromServices] HighscoresDbContext context, [FromBody] HighscoreViewModel viewModel) =>
{
    Highscore highscore = new(viewModel.Player, viewModel.Score);

    try
    {
        context.Highscores.Add(highscore);
        context.SaveChanges();

        return Results.Created("/highscores", highscore);
    }
    catch
    {
        return Results.Problem("Falha interna no servidor!");
    }
});

app.Run();
