using Cubitwelve.Src.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Cubitwelve.Src.Extensions;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices(builder.Configuration);
// Load Database Connect Settings
Env.Load();

var user = Env.GetString("DB_USER");
var password = Env.GetString("DB_PASSWORD");
var database = Env.GetString("DB_DATABASE");
var connectionString = $"server=localhost;user={user};password={password};database={database}";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
// Inject DbContext
builder.Services.AddDbContext<DataContext>(opt =>
                opt
                .UseMySql(connectionString, serverVersion)
                // FIXME: Remove the following 3 lines in production
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Create, migrate and seed database
AppSeedService.SeedDatabase(app);

app.Run();