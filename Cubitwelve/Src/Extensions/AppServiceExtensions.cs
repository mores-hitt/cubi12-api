using Cubitwelve.Src.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Cubitwelve.Src.Repositories;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;
using Cubitwelve.Src.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Cubitwelve.Src.Exceptions;

namespace Cubitwelve.Src.Extensions
{
    public static class AppServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            InitEnvironmentVariables();
            AddAutoMapper(services);
            AddServices(services);
            AddSwaggerGen(services);
            AddDbContext(services);
            AddUnitOfWork(services);
            AddAuthentication(services, config);
            AddHttpContextAccesor(services);
        }

        private static void InitEnvironmentVariables()
        {
            Env.Load();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IMapperService, MapperService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICareersService, CareersService>();
        }

        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cubitwelve API", Version = "v1" })
            );

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

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }

        private static IServiceCollection AddAuthentication(IServiceCollection services, IConfiguration config)
        {
            var jwtSecret = Env.GetString("JWT_SECRET") ??
                throw new InvalidJwtException("JWT_SECRET not present in .ENV");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return services;
        }

        private static void AddHttpContextAccesor(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }


    }
}