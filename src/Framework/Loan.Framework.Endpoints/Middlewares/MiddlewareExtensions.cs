using Microsoft.AspNetCore.Builder;

namespace Loan.Framework.Endpoints.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddleware>();
            return builder;
        }

        public static IApplicationBuilder UseRequestResponseLoggingMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestResponseLoggingMiddleware>();
            return builder;
        }
    }
}
