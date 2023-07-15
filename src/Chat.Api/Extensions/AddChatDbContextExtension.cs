using Chat.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Extensions;

public static class AddChatDbContextExtension
{
    public static void AddChatDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<ChatDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ChatDb"));
        });
    }
}
