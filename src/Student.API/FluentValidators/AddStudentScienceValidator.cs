using FluentValidation;
using Student.API.Models.StudentScienceModels;

namespace Student.API.FluentValidators
{
    public class AddStudentScienceValidator:AbstractValidator<AddStudentScienceModel>
    {
        public AddStudentScienceValidator()
        {
            RuleFor(r => r.ScienceId).NotNull();
            RuleFor(r => r.StudentId).NotNull();
        }
    }
}
