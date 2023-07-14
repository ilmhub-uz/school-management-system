using FluentValidation;
using Sciences.API.Models.ScienceModels;

namespace Sciences.API.FluentValidators;

public class CreateScienceModelValidator : AbstractValidator<CreateScienceModel>
{
    public CreateScienceModelValidator()
    {
        RuleFor(r => r.Title).NotNull().MaximumLength(100);
        RuleFor(r => r.Description).NotNull().MinimumLength(1);
        RuleFor(r => r.Name).NotNull().MinimumLength(1).MaximumLength(100);
    }
}