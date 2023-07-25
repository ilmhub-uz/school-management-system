using FluentValidation;
using SchoolManagement.Services.Sciences.Commands;

namespace SchoolManagement.Services.Sciences.Validators;

public class UpdateScienceCommandValidator : AbstractValidator<UpdateScienceCommand>
{
    public UpdateScienceCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MaximumLength(60);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(255);
    }
}