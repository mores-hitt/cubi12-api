using Cubitwelve.Src.Data;
using Cubitwelve.Src.Repositories;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services;
using Cubitwelve.Src.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cubitwelve.Src.Extensions
{
    public static class AppServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            AddSwaggerGen(services);
            AddDbContext(services);
            AddRepositories(services);
            AddServices(services);
            AddAutoMapper(services);
        }

        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt
                => opt.UseSqlite("Data Source=database.db")
            );
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);
        }




    }
}