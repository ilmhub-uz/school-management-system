namespace SchoolManagement.Services.Students.Models.StudentModels;

public class UpdateStudentModel
{
    public IFormFile? Photo { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Username { get; set; }
}