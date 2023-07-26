using FluentValidation;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentModels;
using SchoolManagement.Services.Students.Repositories;
using SchoolManagement.Services.Students.Validators.StudentModelValidators;

namespace SchoolManagement.Services.Students.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateStudentModel>, CreateStudentModelValidation>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentTaskResultRepository, StudentTaskResultRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IStudentManager, StudentManager>();
        services.AddScoped<IStudentTaskResultManager, StudentTaskResultManager>();
    }
}