using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Students.Entities;

public class StudentTaskResult : IAuditable
{
    public Guid TaskId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Content { get; set; }
    public virtual Student? Student { get; set; }
}