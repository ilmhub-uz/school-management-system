using SchoolManagement.Services.Identity.Entities;

namespace SchoolManagement.Services.Identity.Models;

public record UserModel(
    Guid Id,
    string Username,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    UserStatus Status,
    List<string> Roles);

public static class UserExtensions
{
    public static UserModel ToModel(this User user)
    {
        var roles = user.Roles?.Select(r => r.Role.Name).ToList() ?? new List<string>();
        return new UserModel(user.Id, user.Username, user.CreatedAt, user.UpdatedAt, user.Status, roles);
    }
}