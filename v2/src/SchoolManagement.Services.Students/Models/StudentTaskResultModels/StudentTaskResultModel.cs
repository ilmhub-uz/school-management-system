using SchoolManagement.Services.Students.Models.StudentModels;

namespace SchoolManagement.Services.Students.Models.StudentTaskResultModels;

public class StudentTaskResultModel
{
    public Guid TaskId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Content { get; set; }
    public virtual StudentModel? Student { get; set; }
}
