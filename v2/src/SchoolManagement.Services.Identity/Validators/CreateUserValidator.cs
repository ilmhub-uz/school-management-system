using FluentValidation;
using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserModel>
{
	public CreateUserValidator()
	{
		RuleFor(e => e.Username)
			.NotEmpty()
			.Length(4, 50);

		RuleFor(e => e.Password)
			.Equal(e => e.ConfirmPassword)
			.Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
	}
}