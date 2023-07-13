using FluentValidation;
using Identity.Api.Context;
using Identity.Api.Models;
using Identity.Api.Services;
using Identity.Api.Validators;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
	{
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("FreeAspHost"));
        });

		services.AddJwtValidation(configuration);
		services.AddSwaggerWithToken();
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddScoped<TokenService>();
        services.AddScoped<IValidator<CreateUserModel>, CreateUserModelValidator>();

    }
}