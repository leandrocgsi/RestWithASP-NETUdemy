using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Middleware
{
    /// <summary>
    /// Simple intercept on response
    /// Base on https://www.billbogaiv.com/posts/using-aspnet-cores-middleware-to-modify-response-body
    /// </summary>
    /// <remarks>Aonther way http://www.sulhome.com/blog/10/log-asp-net-core-request-and-response-using-middleware
    /// https://github.com/dcomartin/Migrap.AspNetCore.Hateoas
    /// </remarks>
    public class SimpleRensponeInterceptor
    {
        private readonly RequestDelegate _next;

        public SimpleRensponeInterceptor(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Synchronous Invoke for Synchronous controller operations
        /// </summary>
        /// <param name="context"></param>
        public async Task Invoke(HttpContext context)
        {
            await InvokeAsync(context);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var newContent = string.Empty;
            // Store the "pre-modified" response stream.
            var existingBody = context.Response.Body;

            using (var newBody = new MemoryStream())
            {
                // We set the response body to our stream so we can read after the chain of middlewares have been called.
                context.Response.Body = newBody;

                await _next(context);

                // Set the stream back to the original.
                //context.Response.Body = existingBody;

                newBody.Seek(0, SeekOrigin.Begin);

                // newContent will be `Hello`.
                newContent = new StreamReader(newBody).ReadToEnd();
                // application/json; charset=utf-8

                newContent += ", World!";

                // Send our modified content to the response body.
                // await context.Response.WriteAsync(newContent);
                await newBody.CopyToAsync(existingBody);
            }
        }
    }
}