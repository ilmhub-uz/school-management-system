using Chat.Api.Context;
using Chat.Api.Entities;
using Chat.Api.Managers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Managers;

public class UserManager : IUserManager
{
    private readonly ChatDbContext _context;

    public UserManager(ChatDbContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

}
