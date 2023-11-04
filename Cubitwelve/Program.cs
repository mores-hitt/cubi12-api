using Cubitwelve.Src.Extensions;
using Cubitwelve.Src.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
// Because it's the first middleware, it will catch all exceptions
app.UseExceptionHandling(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();



app.UseIsUserEnabled();


#region CORS_CONFIGURATION
app.UseCors(opt =>
{
    opt.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000");
});
#endregion

app.UseHttpsRedirection();

app.MapControllers();

// Create, migrate and seed database
AppSeedService.SeedDatabase(app);

app.Run();