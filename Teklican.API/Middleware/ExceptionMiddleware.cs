
using System.Net;
using Teklican.Contracts.Errors;
using Teklican.Domain.Common.Exceptions;
using Teklican.Domain.Common.Exceptions.Authentication;

namespace Teklican.API.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some thing error");
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case BadRequestException _:
                    statusCode = (int)StatusCodes.Status400BadRequest;
                    break;
                case NotFoundException _:
                    statusCode = (int)StatusCodes.Status404NotFound;
                    break;
                case UnauthorizationException _:
                    statusCode = (int)StatusCodes.Status401Unauthorized;
                    break;
                case DuplicateEmailException _:
                    statusCode = (int)StatusCodes.Status409Conflict;
                    break;
                case EmaiInvalidException _:
                    statusCode = (int)StatusCodes.Status409Conflict;
                    break;
                case PasswordInvalidException _:
                    statusCode = (int)StatusCodes.Status409Conflict;
                    break;
            }


            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = ex.Message,
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorResponse.ToString());
        }
    }

    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
