using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Students.Entities;

public class Student : Entity, IAuditable
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Username { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public StudentStatus Status { get; set; }
    public virtual ICollection<StudentScience>? Sciences { get; set; }
    public virtual ICollection<StudentTaskResult>? TasksResults { get; set; }
    public virtual ICollection<StudentAttendance>? Attendances { get; set; }
}
