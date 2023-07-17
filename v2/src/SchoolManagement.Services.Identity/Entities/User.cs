using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Identity.Entities;

public class User : Entity, IAuditable
{
	public required string Username { get; set; }
	public required string PasswordHash { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }

	public virtual ICollection<UserRole>? Roles { get; set; }
}