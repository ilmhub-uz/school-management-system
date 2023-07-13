using Identity.Api.Context;
using Identity.Api.Models;
using Identity.Api.Services;
using Mapster;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Managers;

public class AccountManager
{
    private readonly AppDbContext _dbContext;
    private readonly TokenService _tokenService;

    public AccountManager(AppDbContext dbContext, TokenService tokenService)
    {
        _dbContext = dbContext;
        _tokenService = tokenService;
    }

    public async Task SignUp(CreateUserModel createUserModel)
    {
        if (await _dbContext.Users.AnyAsync(u => u.UserName == createUserModel.UserName))
        {
            throw new Exception("User with this username already exists ");
        }

        var user = createUserModel.Adapt<User>();

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<string> Login(LoginUserModel loginUserModel)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == loginUserModel.UserName);

        if (user == null || user.Password != loginUserModel.Password )
        {
            throw new Exception("Username or password incorrect");
        }

        var token = _tokenService.GenerateToken(user);
        return token.ToString();
    }

    public async Task<User> Profile()
    {
        var userId = User
    }
}