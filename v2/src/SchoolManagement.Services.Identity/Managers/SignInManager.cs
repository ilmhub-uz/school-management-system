using SchoolManagement.Services.Identity.Models;
using SchoolManagement.Services.Identity.Producers;

namespace SchoolManagement.Services.Identity.Managers;

public class SignInManager : ISignInManager
{
	private readonly ITokenManager _tokenManager;
	private readonly IUserProvider _userProvider;
	private readonly IUserProducer _userProducer;

	public SignInManager(
		ITokenManager tokenManager, 
		IUserProvider userProvider, 
		IUserProducer userProducer)
	{
		_tokenManager = tokenManager;
		_userProvider = userProvider;
		_userProducer = userProducer;
	}

	public ValueTask<UserModel> GetUserAsync()
	{
		throw new NotImplementedException();
	}

	public ValueTask<UserModel> RegisterAsync(CreateUserModel createUserModel)
	{
		throw new NotImplementedException();
	}

	public ValueTask<TokenResultModel> LoginAsync(LoginUserModel loginUserModel)
	{
		throw new NotImplementedException();
	}
}