using System.Security.Claims;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Middlewares
{
    public class IsUserEnabledMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<IsUserEnabledMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public IsUserEnabledMiddleware(
            RequestDelegate next,
            ILogger<IsUserEnabledMiddleware> logger,
            IHostEnvironment env
        )
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, IUsersService usersService)
        {
            var userEmail = context.User.FindFirstValue(ClaimTypes.Email);
            if (!string.IsNullOrEmpty(userEmail))
            {
                var isEnabled = await usersService.IsEnabled(userEmail);
                if (!isEnabled) throw new UnauthorizedAccessException("User is not enabled");
            }
            await _next(context);
        }
    }

    public static class IsUserEnabledMiddlewareExtensions
    {
        public static IApplicationBuilder UseIsUserEnabled(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IsUserEnabledMiddleware>();
        }
    }
}