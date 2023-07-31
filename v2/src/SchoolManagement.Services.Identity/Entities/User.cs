using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Models;

namespace SchoolManagement.Services.Identity.Entities;

public class User : Entity, IAuditable
{
    public required string Username { get; set; }
    public string PasswordHash { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public UserStatus Status { get; set; }

    public virtual ICollection<UserRole> Roles { get; set; } = null!;
}
public static class UserExtensions
{
    public static UserModel ToModel(this User user)
    {
        var roles = user.Roles?.Select(r => r.Role.Name).ToList() ?? new List<string>();
        return new UserModel(user.Id, user.Username, user.CreatedAt, user.UpdatedAt, user.Status, roles);
    }
}