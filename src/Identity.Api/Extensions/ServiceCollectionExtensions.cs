using FluentValidation;
using Identity.Api.Context;
using Identity.Api.FluentValidators;
using Identity.Api.Models;
using Identity.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("IdentityDb"));
        });
        services.AddJwtValidation(configuration);
        services.AddSwaggerWithToken();
        services.AddScoped<IValidator<CreateUserModel>, CreateUserModelValidator>();
        services.AddScoped<TokenService>();
    }
}