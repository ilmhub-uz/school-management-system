using Chat.Api.Repositories;
using Chat.Api.Repositories.Interfaces;

namespace Chat.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddChatServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddChatDbContext(configuration);
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
    }
}
