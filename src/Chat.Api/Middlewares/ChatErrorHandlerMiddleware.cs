namespace Chat.Api.Middlewares;

public class ChatErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ChatErrorHandlerMiddleware> _logger;

    public ChatErrorHandlerMiddleware(RequestDelegate next, ILogger<ChatErrorHandlerMiddleware> logger)
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
            _logger.LogError(e, "Chat internal server error!");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(new { Error = e.Message });
        }
    }
}

