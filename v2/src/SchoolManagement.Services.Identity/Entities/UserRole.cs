namespace SchoolManagement.Services.Identity.Entities;

public class UserRole
{
	public Guid UserId { get; set; }
	public virtual User? User { get; set; }

	public Guid RoleId { get; set; }
	public virtual Role? Role { get; set; }
}