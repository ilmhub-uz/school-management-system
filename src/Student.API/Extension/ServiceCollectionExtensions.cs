using FluentValidation;
using Student.API.FluentValidators;
using Student.API.Models.StudentModels;

namespace Student.API.Extension;

public static partial class ServiceCollectionExtensions
{
    public static void AddModelValidators(this IServiceCollection services)
    {
	    services.AddScoped<IValidator<CreateStudentModel>, CreateStudentModelValidator>();
    }
}