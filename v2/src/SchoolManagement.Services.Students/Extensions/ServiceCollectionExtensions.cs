using FluentValidation;
using SchoolManagement.Services.Students.FluentValidation;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentModels;
using SchoolManagement.Services.Students.Repositories;

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
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IStudentManager, StudentManager>();
    }
}