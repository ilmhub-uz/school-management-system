namespace Student.API.Models.StudentModels;

public class UpdateStudentModel
{
    public IFormFile? StudentImage { get; set; }
    public string? FirstName { get; set;}
    public string? LastName { get; set;}
    public string? MiddleName { get; set;}
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }
}
