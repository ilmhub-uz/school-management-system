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



        services.AddScoped<IValidator<CreateScienceModel>, CreateScienceModelValidator>();

        services.AddScoped<IScienceRepository, ScienceRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();

        services.AddScoped<ITopicTaskManager,TopicTaskManager>();
        
        services.AddScoped<ScienceManager>();
        services.AddScoped<TopicManager>();
        services.AddScoped<ParseService>();
    }
}