using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MiddlewareExceptionHandler
    {
        private readonly RequestDelegate _next;
        public MiddlewareExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return Task.CompletedTask;
        }
    }
}
