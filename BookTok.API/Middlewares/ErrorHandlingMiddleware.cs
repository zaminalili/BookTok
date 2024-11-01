﻿using BookTok.Domain.Exceptions;

namespace BookTok.API.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, 404, ex, ex.Message);
            }
            catch (UserMismatchException ex)
            {
                await HandleExceptionAsync(context, 403, ex, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, 500, ex, ex.Message);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, int statusCode, Exception ex, string message)
        {
            logger.LogError(ex, message);
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(message);
        }
    }
}
