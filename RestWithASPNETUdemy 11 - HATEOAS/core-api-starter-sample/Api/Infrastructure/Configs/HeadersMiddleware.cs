namespace Api.Infrastructure.Configs
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class HeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public HeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
                context.Response.Headers.Append("Pragma", "no-cache");
                context.Response.Headers.Append("Expires", "0");
                return Task.CompletedTask;
            });

            await _next.Invoke(context);
        }
    }
}