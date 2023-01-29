using Microsoft.EntityFrameworkCore;
using MoreJeeps.Api.Database;
using MoreJeeps.Api.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add logging
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog(logger);

// Add services to the container.
builder.Services.AddControllers();

var dbConnectionString = builder.Configuration["Database:ConnectionString"];
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MoreJeepsContext>(
        options => options.UseSqlite(dbConnectionString)
    );
}
else
{
    builder.Services.AddDbContext<MoreJeepsContext>(
        options => options.UseSqlServer(dbConnectionString)
    );
}

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ISightingRepository, SightingRepository>();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ISightingService, SightingService>();



var app = builder.Build();


// There is an assumption that the database may not exist.  If not,
// it must be created.
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<MoreJeepsContext>()!;
context.Database.EnsureCreated();



app.UseHttpsRedirection();

app.MapControllers();

app.Run();
