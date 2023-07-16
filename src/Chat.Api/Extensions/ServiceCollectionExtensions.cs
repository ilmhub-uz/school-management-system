using Chat.Api.Managers;
using Chat.Api.Managers.Interfaces;
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
        services.AddScoped<IChatManager, ChatManager>();
        services.AddScoped<IMessageManager, MessageManager>();
    }
}
