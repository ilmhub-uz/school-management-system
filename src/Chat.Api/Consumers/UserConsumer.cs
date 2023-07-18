using Chat.Api.Entities;
using Chat.Api.Managers;
using MassTransit;

namespace Chat.Api.Consumers;

public class UserConsumer : IConsumer<User>
{
    private readonly UserManager _userManager;

    public UserConsumer(UserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<User> context)
    {
        var user = context.Message;

        await _userManager.AddUser(user);
    }
}
