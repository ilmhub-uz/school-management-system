namespace Identity.Api.MiddleWares;

public class IdentityErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<IdentityErrorHandlerMiddleware> _logger;

    public IdentityErrorHandlerMiddleware(RequestDelegate next, ILogger<IdentityErrorHandlerMiddleware> logger)
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
            _logger.LogError(e, "Identity internal server error!");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Message = e.Message,
            });
        }
    }
}

public static class ErrorHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseIdentityErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<IdentityErrorHandlerMiddleware>();
    }
}