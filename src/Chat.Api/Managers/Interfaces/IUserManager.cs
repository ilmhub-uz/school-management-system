using Chat.Api.Entities;

namespace Chat.Api.Managers.Interfaces;

public interface IUserManager
{
    public Task AddUser(User user);
}
