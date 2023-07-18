using FluentValidation;
using Student.API.Models.StudentScienceModels;

namespace Student.API.FluentValidators;

public class UpdateStudentScienceValidator : AbstractValidator<UpdateStudentScienceModel>
{
    public UpdateStudentScienceValidator()
    {
        
        RuleFor(s => s.Status).NotNull();
        
    }
}