//using FluentValidation;
//using Sciences.API.Models.TopicModels;

namespace Sciences.API.FluentValidators;



public class CreateTopicValidator : AbstractValidator<CreateTopicModel>
{
    public CreateTopicValidator()
    {
        RuleFor(t => t.Name)
            .NotNull()
            .Length(3, 50)
            .WithMessage("Topic Name should have at least 3 letters and 50 letters maximum");

        RuleFor(t => t.Title)
            .NotNull()
            .WithMessage("it can not be empty");

    }
}
