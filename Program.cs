using Microsoft.EntityFrameworkCore;
using MyApp.Models;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

var PGHOST = Environment.GetEnvironmentVariable("PGHOST");
var PGDATABASE = Environment.GetEnvironmentVariable("PGDATABASE");
var PGUSER = Environment.GetEnvironmentVariable("PGUSER");
var PGPASSWORD = Environment.GetEnvironmentVariable("PGPASSWORD");

var connectionString = $"Host={PGHOST};Database={PGDATABASE};Username={PGUSER};Password={PGPASSWORD}";

builder.Services.AddDbContext<DatabaseContext>(
    opt =>
    {
      opt.UseNpgsql(connectionString);
      if (builder.Environment.IsDevelopment())
      {
        opt
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors();
      }
    }
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
