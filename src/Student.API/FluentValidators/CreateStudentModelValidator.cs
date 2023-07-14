using FluentValidation;
using Student.API.Models.StudentModels;

namespace Student.API.FluentValidators;

public class CreateStudentModelValidator : AbstractValidator<CreateStudentModel>
{
    public CreateStudentModelValidator()
    {
        RuleFor(r => r.FirstName)
            .MaximumLength(100).MinimumLength(1);
        RuleFor(r => r.LastName)
            .MaximumLength(100).MinimumLength(1);
        RuleFor(r => r.MiddleName)
            .MaximumLength(100).MinimumLength(1);
        RuleFor(r => r.Username)
            .NotNull().MaximumLength(100).MinimumLength(1);
        RuleFor(r => r.PhoneNumber)
            .NotNull().MaximumLength(100).MinimumLength(1);
    }
}