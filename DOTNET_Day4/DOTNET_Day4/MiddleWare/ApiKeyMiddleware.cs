using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DOTNET_Day4.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private  string ApiKeyHeader = "VIRATKOHLI";
        private  string ValidApiKey = "18";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Headers[ApiKeyHeader] != ValidApiKey)
            {
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                return httpContext.Response.WriteAsync("Bhaisaaaaa  Invalid API Key!!!!!!!!!!");
            }
            return _next(httpContext);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}