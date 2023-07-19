using Microsoft.EntityFrameworkCore;
using Sciences.API.Context;

namespace Sciences.API.Extension;

public static class AddScienceDbContextExtension
{
    public static void AddScienceDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        var connectionString = configuration.GetConnectionString("ScienceDb");

        services.AddDbContext<ScienceDbContext>(config =>
        {
            config.UseNpgsql(connectionString);
        });
    }
}