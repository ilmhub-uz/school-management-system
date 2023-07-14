using FluentValidation;
using Student.API.FluentValidators;
using Student.API.Models.StudentModels;

namespace Student.API.Extension;

public static class ServiceCollectionExtensions
{
    public static void AddStudentServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddStudentDbContext(configuration);
        services.AddScoped<IValidator<CreateStudentModel>, CreateStudentModelValidator>();
    }
}