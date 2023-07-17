using Chat.Api.Models.MessageModels;
using FluentValidation;

namespace Chat.Api.FluentValidators;

public class CreateMessageModelValidator : AbstractValidator<CreateMessageModel>
{
    public CreateMessageModelValidator()
    {
        RuleFor(m => m.ChatId).NotEmpty();
        RuleFor(m => m.Content).NotEmpty();
    }
}
