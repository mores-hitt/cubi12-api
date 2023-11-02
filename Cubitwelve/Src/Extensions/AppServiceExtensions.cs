namespace Cubitwelve.Src.Extensions
{
    public static class AppServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            AddSwaggerGen(services);
        }

        private static void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}