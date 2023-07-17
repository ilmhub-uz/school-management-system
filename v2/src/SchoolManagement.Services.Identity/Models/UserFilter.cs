namespace SchoolManagement.Services.Identity.Models;

public class UserFilter
{
	public string? UserName { get; set; }
	public DateTime? FromCreatedAt { get; set; }
	public DateTime? ToCreatedAt { get; set; }
	public string? Role { get; set; }
}