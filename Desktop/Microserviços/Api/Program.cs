using Api.Routes;
using Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDatabase();
builder.Services.DependencyInjection();

var app = builder.Build();

app.MapGet("/", () => "Hi, Mom!");

app.MapGet("/test", ()=> "rota funcionando");

app.ConfigureRoutes();

app.Run("http://localhost:3001");
