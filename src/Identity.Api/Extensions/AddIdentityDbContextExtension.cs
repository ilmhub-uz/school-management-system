using Identity.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Extensions;

public static class AddIdentityDbContextExtension
{
    public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("IdentityDb"));
        });
    }
}