using FluentValidation;
using Identity.Api.Models;

namespace Identity.Api.FluentValidators;

public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
{
    public CreateUserModelValidator()
    {
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Name).NotNull();
        RuleFor(u => u.Password).NotNull();
        RuleFor(u => u.UserName).NotNull()
            .MinimumLength(1).MaximumLength(50);

        /*When(condition, () =>
        {
            RuleFor(u => u.Name).NotNull();

        }).Otherwise(() =>
        {
            RuleFor(u => u.Name).Null();
        });*/
    }
}