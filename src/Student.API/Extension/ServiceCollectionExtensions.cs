using FluentValidation;
using Student.API.FluentValidators;
using Student.API.HelperEntities.PaginationEntities;
using Student.API.Managers;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentModels;

namespace Student.API.Extension;

public static partial class ServiceCollectionExtensions
{
    public static void AddModelValidators(this IServiceCollection services)
    {
	    services.AddScoped<IValidator<CreateStudentModel>, CreateStudentModelValidator>();
    }

    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<HttpContextHelper>();
        services.AddScoped<IStudentManager, StudentManager>();
    }
}