using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Managers;

public class UserManager : IUserManager
{
	private readonly ITokenManager _tokenManager;
	private readonly IUserProvider _userProvider;

	public UserManager(ITokenManager tokenManager, IUserProvider userProvider)
	{
		_tokenManager = tokenManager;
		_userProvider = userProvider;
	}

	public ValueTask<IList<UserModel>> GetUsersAsync(UserFilter filter)
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserModel> GetUserAsync(string username)
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserModel> GetUserAsync(Guid id)
	{
		throw new NotImplementedException();
	}
}