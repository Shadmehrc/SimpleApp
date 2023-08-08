using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace LogMiddleWare.Service
{
    public class RequestLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            LogRequest(context);
            await next(context);
            LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            if (!context.Request.Body.CanSeek)
                context.Request.EnableBuffering();
            var deserializedRequest = await HttpContextBodyDeserializer(context.Request.Body);
            _logger.LogInformation($"Request Received From Ip:{context.Connection.RemoteIpAddress} With Request Body: {deserializedRequest}");
        }

        private async void LogResponse(HttpContext context)
        {

            _logger.LogInformation($"Response Status Code: {context.Response.StatusCode}");
        }

        public async Task<string> HttpContextBodyDeserializer(Stream body)
        {
            var reader = new StreamReader(body, Encoding.UTF8);
            var result = await reader.ReadToEndAsync();
            body.Position = 0;
            return result;
        }

    }
}
