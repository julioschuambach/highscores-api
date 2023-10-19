# highscores-api
 
## Introduction
This project consists of a Minimal ASP.NET API, for highscores management of a platformer game made with Unity game engine.

## Requirements
> .NET 6

## How to use
### Restoring the project
`dotnet restore`

### Building the project
`dotnet build`

### Running the project
`dotnet run`

After running the project, you can access the API by the following link: 

## Endpoints
**Post**
`/highscores` - Used to post a new highscore

**Get**
`/highscores` - Used to get all highscores<br>
`/highscores/{player}` - Used to get all highscores from a specific player
