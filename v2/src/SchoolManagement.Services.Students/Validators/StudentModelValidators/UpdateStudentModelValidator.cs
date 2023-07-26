using FluentValidation;
using SchoolManagement.Services.Students.Models.StudentModels;

namespace SchoolManagement.Services.Students.Validators.StudentModelValidators
{
    public class UpdateStudentModelValidator : AbstractValidator<UpdateStudentModel>
    {
        public UpdateStudentModelValidator()
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
}
