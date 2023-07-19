using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Identity.Context;
using SchoolManagement.Services.Identity.Exceptions;
using SchoolManagement.Services.Identity.Helpers;
using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Managers;

public class UserManager : IUserManager
{
    private readonly IdentityDbContext _identityDbContext;

	public UserManager(
        IdentityDbContext identityDbContext)
	{
        _identityDbContext = identityDbContext;
    }

	public async ValueTask<IEnumerable<UserModel>> GetUsersAsync(UserFilter filter)
    {
        var query = _identityDbContext.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.UserName)) 
            query = query.Where(u => u.Username.Contains(filter.UserName));

        if (filter.FromCreatedAt is not null) 
            query = query.Where(u => u.CreatedAt > filter.FromCreatedAt);

        if (filter.ToCreatedAt is not null) 
            query = query.Where(u => u.CreatedAt < filter.ToCreatedAt);

        if (filter.Role is not null)
            query = query.Where(u => u.Roles.Any(r => r.Role.Name == filter.Role));

        return await query.Select(u => u.ToModel()).ToPagedListAsync(filter);
    }

	public async ValueTask<UserModel> GetUserAsync(string username)
    {
        var user = await _identityDbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
        if (user is null)
        {
            throw new NotFoundException("User");
        }

        return user.ToModel();
    }

	public async ValueTask<UserModel> GetUserAsync(Guid id)
    {
        var user = await _identityDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (user is null)
        {
            throw new NotFoundException("User");
        }

        return user.ToModel();
    }
}