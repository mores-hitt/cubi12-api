using Cubitwelve.Src.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Cubitwelve.Src.Repositories;
using Cubitwelve.Src.Repositories.Interfaces;

namespace Cubitwelve.Src.Extensions
{
    public static class AppServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            InitEnvironmentVariables();
            AddSwaggerGen(services);
            AddDbContext(services);
            AddUnitOfWork(services);
        }

        private static void InitEnvironmentVariables()
        {
            Env.Load();
        }

        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        private static void AddDbContext(IServiceCollection services)
        {
            var user = Env.GetString("DB_USER");
            var password = Env.GetString("DB_PASSWORD");
            var database = Env.GetString("DB_DATABASE");
            var connectionString = $"server=localhost;user={user};password={password};database={database}";

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            // Inject DbContext
            services.AddDbContext<DataContext>(opt =>
                            opt
                            .UseMySql(connectionString, serverVersion)
                            // TODO: Remove the following 3 lines in production
                            .LogTo(Console.WriteLine, LogLevel.Information)
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors()
            );
        }

        private static void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}