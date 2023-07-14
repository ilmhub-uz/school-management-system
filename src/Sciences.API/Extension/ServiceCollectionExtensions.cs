using Sciences.API.FluentValidators;

namespace Sciences.API.Extension;

public static class ServiceCollectionExtensions
{
    public static void AddScienceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScienceDbContext(configuration);
        services.AddScoped<CreateScienceModelValidator>();
    }
}