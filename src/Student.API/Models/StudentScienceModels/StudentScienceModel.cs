using Student.API.Entities;

namespace Student.API.Models.StudentScienceModels;

public class StudentScienceModel
{
    public required Guid ScienceId { get; set; }
    public required Guid StudentId { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Status Status { get; set; }
}