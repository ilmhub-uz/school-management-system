using FluentValidation;
using Student.API.Models.StudentModels;

namespace Student.API.FluentValidators;

public class UpdateStudentModelValidator : AbstractValidator<UpdateStudentModel>
{
    public UpdateStudentModelValidator()
    {
        RuleFor(p => p.FirstName).MinimumLength(1).MaximumLength(100);
        RuleFor(p => p.LastName).MinimumLength(1).MaximumLength(100);
        RuleFor(p => p.MiddleName).MinimumLength(1).MaximumLength(100);
        RuleFor(p => p.Username).MinimumLength(1).MaximumLength(100);
        RuleFor(p => p.PhoneNumber).MinimumLength(1).MaximumLength(100);
    }
}