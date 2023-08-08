using LogMiddleWare.Service;
using Microsoft.AspNetCore.Builder;

namespace LogMiddleWare;

public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>();
    }
}