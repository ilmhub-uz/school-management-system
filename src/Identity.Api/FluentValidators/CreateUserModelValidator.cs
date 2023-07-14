using FluentValidation;
using Identity.Api.Models;

namespace Identity.Api.FluentValidators;

public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
{
    public CreateUserModelValidator()
    {
        RuleFor(u => u.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(20).WithMessage("Your password length must not exceed 20.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        
        RuleFor(u => u.UserName).NotEmpty()
            .MinimumLength(6).MaximumLength(30);
    }
}