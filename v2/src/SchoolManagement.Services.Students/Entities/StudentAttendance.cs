namespace SchoolManagement.Services.Students.Entities;

public class StudentAttendance
{
    public required Guid TopicId { get; set; }
    public required Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public bool Attend { get; set; }
}