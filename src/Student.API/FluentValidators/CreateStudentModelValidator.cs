using FluentValidation;
using Student.API.Models.StudentModels;

namespace Student.API.FluentValidators;

public class CreateStudentModelValidator : AbstractValidator<CreateStudentModel>
{
    public CreateStudentModelValidator()
    {
        
    }
}