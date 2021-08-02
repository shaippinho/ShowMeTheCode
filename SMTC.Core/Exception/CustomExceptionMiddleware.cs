using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SMTC.Core.Controllers;
using System.Net;
using System.Threading.Tasks;

namespace SMTC.Core.Exception
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomExceptionMiddleware(
            RequestDelegate next 
            ,ILogger<CustomExceptionMiddleware> logger
            )
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }

        private async void HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            _logger.LogCritical(exception?.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //await context.Response.WriteAsync(exception.ToString());
            await context.Response.WriteAsync((new CustomErrorModel(exception)).ToString());
        }
    }
}
