using FluentValidation;
using SchoolManagement.Services.Sciences.Commands;

namespace SchoolManagement.Services.Sciences.Validators;

public class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    public CreateTopicCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MaximumLength(60);
        RuleFor(c => c.Description).MaximumLength(255);
    }
}