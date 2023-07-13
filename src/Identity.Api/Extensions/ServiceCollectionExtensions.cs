using Identity.Api.Context;
using Identity.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FreeAspHost"));
        });

        services.AddJwtValidation(configuration);
        services.AddSwaggerWithToken();

        services.AddScoped<TokenService>();
    }
}