using FluentValidation;
using Student.API.Models.StudentTaskResults;

namespace Student.API.FluentValidators;

public class AddStudentTaskResultValidator:AbstractValidator<AddStudentTaskResultModel>
{
    public AddStudentTaskResultValidator()
    {
        RuleFor(r => r.Content)
        .MaximumLength(100).MinimumLength(1);
    }
}
