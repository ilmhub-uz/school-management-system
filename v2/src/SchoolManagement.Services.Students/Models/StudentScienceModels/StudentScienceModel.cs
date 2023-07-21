using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Models.StudentScienceModels;

public class StudentScienceModel
{
    public Guid ScienceId { get; set; }
    public Guid StudentId { get; set; }
    public StudentScienceStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual StudentModel? Student { get; set; }
}
