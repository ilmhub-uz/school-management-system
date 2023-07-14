using Student.API.Entities;

namespace Student.API.Models.CreateStudentModel;

public class CreateStudentModel
{
    public IFormFile? File { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string Username { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public Status Status { get; set; }
}