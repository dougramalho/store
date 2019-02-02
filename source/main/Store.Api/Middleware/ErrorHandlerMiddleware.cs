using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Store.Core.Domain;

namespace Store.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandlerErrorAsync(context, exception);
            }
        }

        private static Task HandlerErrorAsync(HttpContext context, Exception exception)
        {
            var exceptionType = exception.GetType();
            var statusCode = HttpStatusCode.InternalServerError;
            var errorCode = "error";

            switch (exception)
            {
                case StoreException e when exceptionType == typeof(StoreException):
                    errorCode = e.ErrorCode;
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case StoreException e when exceptionType == typeof(UnauthorizedAccessException):
                    errorCode = "unauthorized";
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case StoreException e when exceptionType == typeof(ArgumentException):
                    errorCode = "invalid_parameter";
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            var response = new {message = exception.Message, errorCode = errorCode};
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(payload);
        }
    }
}