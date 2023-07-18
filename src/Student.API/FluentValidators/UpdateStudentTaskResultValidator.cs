using FluentValidation;
using Student.API.Models.StudentTaskResults;

namespace Student.API.FluentValidators;

public class UpdateStudentTaskResultValidator:AbstractValidator<UpdateStudentTaskResultModel>
{
    public UpdateStudentTaskResultValidator()
    {
        
        RuleFor(s => s.Content).NotNull().MaximumLength(100).MinimumLength(1);
        
    }
        


}
