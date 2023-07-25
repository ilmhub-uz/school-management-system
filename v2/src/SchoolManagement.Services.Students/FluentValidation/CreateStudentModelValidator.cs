using FluentValidation;
using SchoolManagement.Services.Students.Models.StudentModels;

namespace SchoolManagement.Services.Students.FluentValidation;

public class CreateStudentModelValidation : AbstractValidator<CreateStudentModel>
{
    public CreateStudentModelValidation()
    {
        RuleFor(r => r.FirstName)
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(r => r.LastName)
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(r => r.MiddleName)
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(r => r.Username)
            .MinimumLength(5)
            .MaximumLength(50);

        RuleFor(r => r.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
    }
}