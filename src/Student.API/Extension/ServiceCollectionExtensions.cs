using FluentValidation;
using Student.API.FluentValidators;
using Student.API.HelperEntities.PaginationEntities;
using Student.API.Managers;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentAttendanceModels;
using Student.API.Models.StudentModels;
using Student.API.Repositories;
using Student.API.Repositories.Interfaces;

namespace Student.API.Extension;

public static partial class ServiceCollectionExtensions
{
    public static void AddModelValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateStudentModel>, CreateStudentModelValidator>();
	    services.AddScoped<IValidator<UpdateStudentAttendanceModel>, UpdateStudentAttendanceValidator>();
	    services.AddScoped<IValidator<UpdateStudentModel>, UpdateStudentModelValidator>();
    }

    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<HttpContextHelper>();
        services.AddScoped<IStudentManager, StudentManager>();
        services.AddScoped<IStudentAttendanceManager, StudentAttendanceManager>();
        services.AddScoped<IStudentScienceManager, StudentScienceManager>();
        services.AddScoped<IStudentTaskResultManager, StudentTaskResultManager>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentAttendanceRepository, StudentAttendanceRepository>();
        services.AddScoped<IStudentScienceRepository, StudentScienceRepository>();
        services.AddScoped<IStudentTaskResultRepository, StudentTaskResultRepository>();
    }
}