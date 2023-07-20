namespace SchoolManagement.Services.Students.Models;

public class CreateStudentModel
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? MiddleName { get; set; }
	public required string PhoneNumber { get; set; }
	public required string Username { get; set; }
	public IFormFile? Photo { get; set; }
}