namespace Chat.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddChatServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddChatDbContext(configuration);
    }
}
