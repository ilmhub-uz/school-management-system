using FluentValidation;
using Sciences.API.FluentValidators;
using Sciences.API.Managers;
using Sciences.API.Models.ScienceModels;
using Sciences.API.ParseHelper;
using Sciences.API.Repositories;
using Sciences.API.Repositories.Interfaces;

namespace Sciences.API.Extension;

public static class ServiceCollectionExtensions
{
    public static void AddScienceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScienceDbContext(configuration);
        services.AddScoped<IValidator<CreateScienceModel>, CreateScienceModelValidator>();
        services.AddScoped<IScienceRepository, ScienceRepository>();
        services.AddScoped<ScienceManager>();
        services.AddScoped<ParseService>();

        services.AddScoped<ITopicTaskRepository, TopicTaskRepository>();
    }
}