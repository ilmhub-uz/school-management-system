using Chat.Api.Models.ChatModels;
using FluentValidation;

namespace Chat.Api.FluentValidators;

public class CreateChatModelValidator : AbstractValidator<CreateChatModel>
{
    public CreateChatModelValidator()
    {
        RuleFor(c => (int)c.ChatType).IsInEnum().GreaterThanOrEqualTo(0).LessThanOrEqualTo(3);
    }
}
