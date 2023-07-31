using SchoolManagement.Core.Models;
using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Managers;

public interface IUserManager
{
    ValueTask<IEnumerable<UserModel>> GetUsersAsync(UserFilter filter);
    ValueTask<UserModel> GetUserAsync(string username);
    ValueTask<UserModel> GetUserAsync(Guid id);
}