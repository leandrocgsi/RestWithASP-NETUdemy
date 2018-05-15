using Microsoft.AspNetCore.Builder;

namespace RestWithASPNETUdemy.Middleware
{
    /// <summary>
    /// Extension class for registration
    /// </summary>
    public static class SimpleRensponeInterceptorExtension
    {
        public static IApplicationBuilder UseSimpleRensponeInterceptor(
         this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleRensponeInterceptor>();
        }
    }
}