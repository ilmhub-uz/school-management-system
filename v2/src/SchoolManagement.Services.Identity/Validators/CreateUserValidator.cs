using FluentValidation;
using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserModel>
{
	public CreateUserValidator()
	{
		RuleFor(e => e.Username).NotEmpty();
	}
}