using FluentValidation;
using Student.API.Models.StudentAttendanceModels;

namespace Student.API.FluentValidators;

public class AddStudentAttendanceValidator: AbstractValidator<AddStudentAttendanceModel>
{
    public AddStudentAttendanceValidator() 
    {
        RuleFor(r => r.TopicId).NotNull();
        RuleFor(r => r.StudentId).NotNull(); 
    }

}
