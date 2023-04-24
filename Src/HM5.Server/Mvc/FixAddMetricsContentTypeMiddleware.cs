namespace HM5.Server.Mvc
{
    public class FixAddMetricsContentTypeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //NOTE: AddMetrics-requests don't have a proper Content-Type set...
            if (
                context.Request.Path is { HasValue: true, Value: not null } && 
                context.Request.Path.Value.EndsWith("/AddMetrics")
            )
            {
                context.Request.ContentType = "application/json";
            }

            await next(context);
        }
    }
}
