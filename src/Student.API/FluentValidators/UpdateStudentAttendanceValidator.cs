using FluentValidation;
using Student.API.Models.StudentAttendanceModels;

namespace Student.API.FluentValidators;

public class UpdateStudentAttendanceValidator : AbstractValidator<UpdateStudentAttendanceModel>
{
    public UpdateStudentAttendanceValidator()
    {
        RuleFor(s => s.Attend).NotNull();

    }
}
