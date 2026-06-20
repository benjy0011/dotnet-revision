using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
        new (
            1,
            "Street Fighter II",
            "Fighting",
            19.99M,
            new DateOnly(1992, 7, 15)
        ),
        new (
            2,
            "Street Fighter III",
            "Fighting",
            29.99M,
            new DateOnly(1993, 7, 15)
        ),
        new (
            3,
            "Street Fighter IV",
            "Fighting",
            39.99M,
            new DateOnly(1994, 7, 15)
        )
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(g => g.Id == id);

            if (game is null) return Results.NotFound();

            return Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            // 1st: Route to get the created resource
            // 2nd: param to get
            // 3rd: resource created
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });


        // the compiler is smart enuf to know
        // 1st param coming from route
        // 2nd param coming from body
        // PUT /games/1
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(g => g.Id == id);

            if (index == -1) return Results.NotFound();

            games[index] = new GameDto(
                id,
                updateGame.Name,
                updateGame.Genre,
                updateGame.Price,
                updateGame.ReleaseDate
            );

            return Results.NoContent();
        });


        // DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
    }

}
