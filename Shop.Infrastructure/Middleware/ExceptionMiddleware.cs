using Microsoft.AspNetCore.Http;
using Shop.Infrastructure.Exceptions;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Middleware
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
                case NotAuthorizedException:
                    message = exception.Message;
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ValidationException:
                    message = exception.Message;
                    code = HttpStatusCode.BadRequest;
                    break;
                case DublicateException:
                    message = exception.Message;
                    code = HttpStatusCode.BadRequest;
                    break;
                case RestrictionOfGoodsException:
                    message = exception.Message;
                    code = HttpStatusCode.BadRequest;
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
