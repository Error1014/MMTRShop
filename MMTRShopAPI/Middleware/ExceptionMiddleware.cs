using MMTRShop.Service.Interface;
using MMTRShop.Service.Services;
using MMTRShopAPI.Middleware.Exceptions;
using System.Net;
using System.Text.Json;

namespace MMTRShopAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            var exceptionType = exception.GetType();
            switch (exception)
            {
                case NotFoundException:
                    message = exception.Message;
                    code = HttpStatusCode.NotFound;
                    break;
                default:
                    message = exception.Message;
                    break;
            }


            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
