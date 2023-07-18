using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Students.Entities;

public class StudentScience : IAuditable
{
    public Guid ScienceId { get; set; }
    public Guid StudentId { get; set; }
    public StudentScienceStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Student? Student { get; set; }
}