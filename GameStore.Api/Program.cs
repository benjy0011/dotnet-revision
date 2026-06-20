using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Available for valdation for data annotation
builder.Services.AddValidation();

var app = builder.Build();


app.MapGamesEndpoints();

app.Run();
