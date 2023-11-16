using Cubitwelve.Src.Extensions;
using Cubitwelve.Src.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .WithOrigins("http://localhost:3000",
                                              "http://localhost",
                                              "https://cubitwelve.azurewebsites.net",
                                              "https://cubi12.cl");
                      });
});
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


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.UseIsUserEnabled();

app.UseHttpsRedirection();

app.MapControllers();

// Create, migrate and seed database
AppSeedService.SeedDatabase(app);

app.Run();