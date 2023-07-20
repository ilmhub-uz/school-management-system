using Chat.Api.Entities;
using Chat.Api.Managers;
using Chat.Api.Managers.Interfaces;
using MassTransit;

namespace Chat.Api.Consumers;

public class UserConsumer : IConsumer<User>
{
    private readonly IUserManager _userManager;

    public UserConsumer(IUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<User> context)
    {
        var user = context.Message;

        await _userManager.AddUser(user);
    }
}
