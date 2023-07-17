using FluentValidation;
using Student.API.Models.StudentScienceModels;

namespace Student.API.FluentValidators
{
    public class UpdateStudentScienceValidor:AbstractValidator<UpdateStudentScienceModel>
    {
        public UpdateStudentScienceValidor()
        {
            RuleFor(s => s.ScienceId).NotNull();
            RuleFor(s => s.StudentId).NotNull();
            RuleFor(s => s.Status).NotNull();
            RuleFor(s => s.CreateAt).NotNull();
        }
    }
}
