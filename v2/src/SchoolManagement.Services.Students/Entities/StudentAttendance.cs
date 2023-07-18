namespace SchoolManagement.Services.Students.Entities;

public class StudentAttendance
{
    public required Guid TopicId { get; set; }
    public required Guid StudentId { get; set; }
    public bool Attend { get; set; }
}