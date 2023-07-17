namespace SchoolManagement.Services.Identity.Models;

public class CreateUserModel
{
	public required string Username { get; set; }
	public required string Password { get; set; }
	public required string ConfirmPassword { get; set; }
}