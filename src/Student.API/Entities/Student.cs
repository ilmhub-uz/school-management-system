namespace Student.API.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set;}
    public string? MiddleName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime CreDateTime => DateTime.Now;
    public DateTime? UpdateTime { get; set; }
    public EStudentStatus Status { get; set; }
}