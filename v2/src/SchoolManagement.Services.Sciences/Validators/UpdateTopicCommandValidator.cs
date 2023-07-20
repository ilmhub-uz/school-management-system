using FluentValidation;
using SchoolManagement.Services.Sciences.Commands;

namespace SchoolManagement.Services.Sciences.Validators;

public class UpdateTopicCommandValidator : AbstractValidator<UpdateTopicCommand>
{
	public UpdateTopicCommandValidator()
	{
		RuleFor(c => c.Title).NotEmpty().MaximumLength(60);
		RuleFor(c => c.Description).MaximumLength(255);
    }
}