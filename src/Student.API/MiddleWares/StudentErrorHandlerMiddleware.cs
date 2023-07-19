namespace Student.API.MiddleWares;

public class StudentErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<StudentErrorHandlerMiddleware> _logger;

    public StudentErrorHandlerMiddleware(RequestDelegate next, ILogger<StudentErrorHandlerMiddleware> logger)
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
            _logger.LogError(e, "Student internal server error!");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(new { Error = e.Message });
        }
    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseStudentErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<StudentErrorHandlerMiddleware>();
    }
}