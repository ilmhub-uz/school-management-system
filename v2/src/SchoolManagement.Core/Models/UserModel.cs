namespace SchoolManagement.Core.Models;

public record UserModel(
    Guid Id,
    string Username,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    UserStatus Status,
    List<string> Roles);

