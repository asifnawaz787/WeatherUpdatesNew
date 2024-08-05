using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WeatherUpdates.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiLogerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiLogerMiddleWare> _logger;

        public ApiLogerMiddleWare(RequestDelegate next, ILogger<ApiLogerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            Console.WriteLine("LoggingMiddleware invoked.");

            var originalBody = httpContext.Response.Body;
            var newBody = new MemoryStream();
            httpContext.Response.Body = newBody;
            try
            {
                return _next(httpContext);
            } finally
            {
                newBody.Seek(0, SeekOrigin.Begin);
                var bodyText =  new StreamReader(newBody).ReadToEndAsync();
                Console.WriteLine($"LoggingMiddleware: {bodyText}");
                newBody.Seek(0, SeekOrigin.Begin);
                 newBody.CopyToAsync(originalBody);
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiLogerMiddleWareExtensions
    {
        public static IApplicationBuilder UseApiLogerMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiLogerMiddleWare>();
        }
    }

    public class handleRequestResponse
    {
        public void LogRequest(HttpContent httpContext)
        {

        }
        public void LogResponse(HttpContext httpContext)
        {

        }
    }
}
