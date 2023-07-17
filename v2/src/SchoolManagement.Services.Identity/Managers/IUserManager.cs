using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Managers;

public interface IUserManager
{
	ValueTask<IList<UserModel>> GetUsersAsync(UserFilter filter);
	ValueTask<UserModel> GetUserAsync(string username);
	ValueTask<UserModel> GetUserAsync(Guid id);
}