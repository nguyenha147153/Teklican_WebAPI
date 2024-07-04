using System.Net;
using System.Text.Json;
using Teklican.Application.Exceptions;
using Teklican.Application.Wrapper;
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
            var responseModel = new Response<string>() { Succeeded = false, Message = ex.Message};

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
                case ValidationException e:
                    statusCode = (int)StatusCodes.Status400BadRequest;
                    responseModel.Errors = e.Errors;
                    break;
            }

            responseModel.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(responseModel);
            return context.Response.WriteAsync(result);
        }
    }
}
