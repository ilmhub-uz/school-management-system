using Chat.Api.Context;
using Chat.Api.FluentValidators;
using Chat.Api.Managers;
using Chat.Api.Managers.Interfaces;
using Chat.Api.Models.ChatModels;
using Chat.Api.Models.MessageModels;
using Chat.Api.Repositories;
using Chat.Api.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddChatServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IChatManager, ChatManager>();
        services.AddScoped<IMessageManager, MessageManager>();
        services.AddScoped<IValidator<CreateMessageModel>, CreateMessageModelValidator>();
        services.AddScoped<IValidator<CreateChatModel>, CreateChatModelValidator>();
    }

    public static void AddChatDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<ChatDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ChatDb"));
        });
    }
}
