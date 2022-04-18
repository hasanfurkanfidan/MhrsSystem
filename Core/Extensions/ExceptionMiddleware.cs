using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = exception.Message;
  
             if (exception.GetType() == typeof(ApplicationException))
            {
                message = exception.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exception.GetType() == typeof(UnauthorizedAccessException))
            {
                message = exception.Message;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (exception.GetType() == typeof(SecurityException))
            {
                message = exception.Message;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (exception.GetType() == typeof(DbUpdateException))
            {
                if (exception.InnerException != null)
                    message = exception.InnerException.Message;
            }     
            else if (exception.GetType() == typeof(InvalidOperationException))
            {
                if (exception.Message.Contains("Unable to resolve service for type"))
                    message = $"Dependency Injection Reference Hatası = {exception.Message}";
                else if (exception.Message.StartsWith("Cannot create a DbSet for") &&
                         exception.Message.EndsWith("because this type is not included in the model for the context."))
                    message = "Yeni eklemiş olduğun tablo class bilgisini DataAccess>Concrete>Context içine eklemememişssin.";
            }
            else
            {
                while (exception.InnerException != null)
                {
                    message += exception.InnerException;
                    exception = exception.InnerException;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            await httpContext.Response.WriteAsync(message);
        }
    }
}
