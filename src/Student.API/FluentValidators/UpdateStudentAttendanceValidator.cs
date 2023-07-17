using FluentValidation;
using Student.API.Models.StudentAttendanceModels;

namespace Student.API.FluentValidators
{
    public class UpdateStudentAttendanceValidator:AbstractValidator<UpdateStudentAttendanceModel>
    {
        public UpdateStudentAttendanceValidator()
        {
            RuleFor(s => s.TopicId).NotNull();
            RuleFor(s => s.StudentId).NotNull();
        }
    }
}
