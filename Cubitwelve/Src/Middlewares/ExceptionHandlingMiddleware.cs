using Cubitwelve.Src.Common.Constants;
using Cubitwelve.Src.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Text.Json;


namespace Cubitwelve.Src.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IHostEnvironment env
        )
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidCredentialException ex)
            {
                await GenerateHttpResponse(ex, context, ErrorMessages.InvalidCredentials, 404);
            }
            catch (EntityNotFoundException ex)
            {
                await GenerateHttpResponse(ex, context, ErrorMessages.EntityNotFound, 404);
            }
            catch (EntityNotDeletedException ex)
            {
                await GenerateHttpResponse(ex, context, ErrorMessages.EntityNotDeleted, 400);
            }
            catch (Exception ex) when (ex is InvalidJwtException || ex is InternalErrorException)
            {
                await GenerateHttpResponse(ex, context, ErrorMessages.InternalServerError, 500);
            }
            catch (DuplicateUserException ex)
            {
                await GenerateHttpResponse(ex, context, ErrorMessages.DuplicateUser, 400);
            }
        }

        private async Task GenerateHttpResponse(
            Exception ex,
            HttpContext context,
            string errorTitle,
            int statusCode
        )
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ProblemDetails
            {
                Status = statusCode,
                Title = errorTitle,
                Detail = ex.Message,
                Instance = context.Request.Path, // Internal API URL that caused the error
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}