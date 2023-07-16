namespace Sciences.API.MiddleWares;

public class ScienceErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ScienceErrorHandlerMiddleware> _logger;

    public ScienceErrorHandlerMiddleware(RequestDelegate next, ILogger<ScienceErrorHandlerMiddleware> logger)
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
        catch (System.Exception e)
        {
            _logger.LogError(e, "Science internal server error!");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(new { Error = e.Message });
        }
    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseScienceErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ScienceErrorHandlerMiddleware>();
    }
}