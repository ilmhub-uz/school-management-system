using Chat.Api.Middlewares;

namespace Chat.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseChatErrorHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ChatErrorHandlerMiddleware>();
    }
}
