using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Available for valdation for data annotation
builder.Services.AddValidation();

// Add DB context (before app)

// command: dotnet ef migrations add {migrationMessage} --output-dir Data/Migrations

// command: dotnet ef database update
// note: replaced by `.MigrateDb()` code, which read the migration file and do something like init/update db

// ps: stop all ongoing process before doing migration
var connString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();


app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
