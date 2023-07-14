namespace Sciences.API.MiddleWares;

public class ScienceErrorHandleMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ScienceErrorHandleMiddleware> _logger;

    public ScienceErrorHandleMiddleware(RequestDelegate next, ILogger<ScienceErrorHandleMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Science internal server error!");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(new { Error = e.Message });
        }
    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseScienceErrorHandleMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ScienceErrorHandleMiddleware>();
    }
}