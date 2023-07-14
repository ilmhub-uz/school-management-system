using Microsoft.EntityFrameworkCore;
using Sciences.API.Context;

namespace Sciences.API.Extension;

public static class ServiceCollectionExtensions
{
    public static void AddScienceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<ScienceDbContext>(config =>
        {
            config.UseNpgsql(configuration.GetConnectionString("ScienceDb"));
        });
    }
}