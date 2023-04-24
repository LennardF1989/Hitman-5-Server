using System.Text;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;

namespace HM5.Server.Mvc
{
    public class RequestResponseLoggerMiddleware : IMiddleware
    {
        private readonly ISimpleLogger _simpleLogger;
        private readonly Options _options;

        public RequestResponseLoggerMiddleware(ISimpleLogger simpleLogger, Options options)
        {
            _simpleLogger = simpleLogger;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                if (_options.EnableRequestBodyLogging)
                {
                    context.Request.EnableBuffering();
                }

                if (_options.EnableResponseBodyLogging)
                {
                    //NOTE: In order to read the response the original stream needs to be replaced with a MemoryStream
                    var originalStream = context.Response.Body;
                    using var memoryStream = new MemoryStream();

                    context.Response.Body = memoryStream;

                    await next(context);

                    _simpleLogger.WriteLine(await LogRequest(context));

                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalStream);

                    context.Response.Body = originalStream;
                }
                else
                {
                    await next(context);

                    _simpleLogger.WriteLine(await LogRequest(context));
                }
            }
            catch (Exception ex)
            {
                _simpleLogger.WriteLine(LogException(context, ex));
            }
        }

        private async Task<string> LogRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"--- Request @ {DateTime.Now} ---");
            stringBuilder.AppendLine($"{request.Method} {request.GetDisplayUrl()}");

            if (
                _options.EnableRequestBodyLogging && 
                request.Method != "GET" && 
                request.ContentLength > 0
            )
            {
                request.Body.Seek(0, SeekOrigin.Begin);
                using var streamReader = new StreamReader(request.Body);
                var body = await streamReader.ReadToEndAsync();

                stringBuilder.AppendLine(body);
            }

            stringBuilder.AppendLine($"--- Response @ {response.StatusCode} ---");

            if (_options.EnableResponseBodyLogging)
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                using var streamReader = new StreamReader(response.Body, leaveOpen: true);
                var body = await streamReader.ReadToEndAsync();

                if (body.Length > 0)
                {
                    stringBuilder.AppendLine(body);
                }
            }

            return stringBuilder.ToString();
        }

        private string LogException(HttpContext context, Exception ex)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"--- Request @ {DateTime.Now} ---");
            stringBuilder.AppendLine($"{context.Request.Method} {context.Request.GetDisplayUrl()}");

            stringBuilder.AppendLine("--- Response @ Exception ---");

            if (ex is ModelStateException modelStateException)
            {
                stringBuilder.AppendLine("The following properties received an invalid value:");

                foreach (var kvp in modelStateException.Errors)
                {
                    stringBuilder.AppendLine($"- {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                stringBuilder.AppendLine(ex.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
