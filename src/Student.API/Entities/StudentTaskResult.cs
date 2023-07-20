namespace Student.API.Entities;

public class StudentTaskResult
{
    public Guid TaskId { get; set; }
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public required string Content { get; set; }
}