namespace SchoolManagement.Services.Students.Models.StudentModels;

public class CreateStudentModel
{
    public IFormFile? Photo { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Username { get; set; }
}