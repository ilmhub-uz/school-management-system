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

        //RuleFor(e => e.Password)
        //    .Equal(e => e.ConfirmPassword)
        //    .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        RuleFor(e => e.Password)
            .Equal(e => e.ConfirmPassword)
            .NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(20).WithMessage("Your password length must not exceed 20.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number."); ;
    }
}