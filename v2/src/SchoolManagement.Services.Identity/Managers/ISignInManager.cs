using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Managers;

public interface ISignInManager
{
	ValueTask<UserModel> GetUserAsync();
	ValueTask<UserModel> RegisterAsync(CreateUserModel createUserModel);
	ValueTask<TokenResultModel> LoginAsync(LoginUserModel loginUserModel);
}