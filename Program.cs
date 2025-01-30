using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = new()
{
    new GameDto(
        1,
        "Super Mario Bros.",
        "Platformer",
        "Nintendo",
        29.99m,
        new DateOnly(1985, 9, 13)
    ),
    new GameDto(
        2,
        "The Legend of Zelda",
        "Action-adventure",
        "Nintendo",
        39.99m,
        new DateOnly(1986, 2, 21)
    ),
    new GameDto(3, "Minecraft", "Sandbox", "Mojang", 19.99m, new DateOnly(2011, 11, 18)),
    new GameDto(4, "Among Us", "Social deduction", "InnerSloth", 4.99m, new DateOnly(2018, 6, 15)),
    new GameDto(
        5,
        "Cyberpunk 2077",
        "Action role-playing",
        "CD Projekt",
        59.99m,
        new DateOnly(2020, 12, 10)
    ),
};

app.MapGet("games", () => games);
app.MapGet(
        "game/{id}",
        (int id) =>
        {
            return games.Find(game => game.Id == id);
        }
    )
    .WithName("getGameById");

app.MapPost(
    "games",
    (CrateGameDto newGame) =>
    {
        GameDto gameData = new GameDto(
            games.Count + 1,
            newGame.Name,
            newGame.Genera,
            newGame.Publisher,
            newGame.Price,
            newGame.ReleaseDate
        );
        games.Add(gameData);
        return Results.CreatedAtRoute("getGameById", new { id = games.Count }, gameData);
    }
);

app.MapPut(
    "game/{id}",
    (int id, UpdateDto updatedValues) =>
    {
        int gameIndex = games.FindIndex(game => game.Id == id);
        GameDto game = games[gameIndex];
        if (gameIndex < 0)
        {
            return Results.NotFound();
        }

        GameDto updatedGame = game with
        {
            Name = updatedValues.Name ?? game.Name,
            Genera = updatedValues.Genera ?? game.Genera,
            Publisher = updatedValues.Publisher ?? game.Publisher,
            Price = updatedValues.Price ?? game.Price,
            ReleaseDate = updatedValues.ReleaseDate ?? game.ReleaseDate,
        };

        games[gameIndex] = updatedGame;

        return Results.CreatedAtRoute("getGameById", new { id = id }, updatedGame);
    }
);

app.MapDelete(
    "game/{id}",
    (int id) =>
    {
        int gameIndex = games.FindIndex(game => game.Id == id);
        if (gameIndex < 0)
        {
            return Results.NotFound();
        }

        games.RemoveAt(gameIndex);

        return Results.NoContent();
    }
);

app.MapGet("/", () => "Hello World!");

app.Run();
