using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Identity.Context;
using SchoolManagement.Services.Identity.Entities;
using SchoolManagement.Services.Identity.Exceptions;
using SchoolManagement.Services.Identity.Models;
using SchoolManagement.Services.Identity.Producers;

namespace SchoolManagement.Services.Identity.Managers;

public class SignInManager : ISignInManager
{
    private readonly ITokenManager _tokenManager;
    private readonly IUserProvider _userProvider;
    private readonly IUserProducer _userProducer;
    private readonly IdentityDbContext _identityDbContext;

    public SignInManager(
        ITokenManager tokenManager,
        IUserProvider userProvider,
        IUserProducer userProducer, IdentityDbContext identityDbContext)
    {
        _tokenManager = tokenManager;
        _userProvider = userProvider;
        _userProducer = userProducer;
        _identityDbContext = identityDbContext;
    }

    public async ValueTask<UserModel> GetUserAsync()
    {
        var user = await _identityDbContext.Users.FindAsync(_userProvider.UserId);

        if (user == null)
        {
            throw new RecordNotFoundException("User");
        }

        return user.ToModel();
    }

    public async ValueTask<UserModel> RegisterAsync(CreateUserModel createUserModel)
    {
        var isUsernameExists = await _identityDbContext.Users.AnyAsync(u => u.Username == createUserModel.Username);
        if (isUsernameExists)
        {
            throw new UsernameExistsException();
        }

        var user = new User()
        {
            Username = createUserModel.Username,
            PasswordHash = createUserModel.Password,
            CreatedAt = DateTime.UtcNow,
            Roles = new List<UserRole>()
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, createUserModel.Password);

        if (createUserModel.Roles?.Count() > 0)
        {
            if (!await _identityDbContext.Roles.AllAsync(r => createUserModel.Roles.Any(cr => cr == r.Id)))
            {
                throw new RecordNotFoundException("Role");
            }

            foreach (var role in createUserModel.Roles)
            {
                user.Roles.Add(new UserRole()
                {
                    RoleId = role
                });
            }
        }

        _identityDbContext.Users.Add(user);
        await _identityDbContext.SaveChangesAsync();

        await _userProducer.PublishUser(user);

        return user.ToModel();
    }

    public async ValueTask<TokenResultModel> LoginAsync(LoginUserModel loginUserModel)
    {
        var user = await _identityDbContext.Users.FirstOrDefaultAsync(u => u.Username == loginUserModel.Username);

        if (user == null || user.PasswordHash != loginUserModel.Password)
        {
            throw new LoginValidationException();
        }

        var (token, expires) = _tokenManager.GenerateToken(user);

        return new TokenResultModel(token, expires, DateTime.UtcNow);
    }
}