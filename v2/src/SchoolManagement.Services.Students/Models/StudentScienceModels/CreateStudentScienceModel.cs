using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Models.StudentScienceModels;

public class CreateStudentScienceModel
{
    public Guid ScienceId { get; set; }
    public Guid StudentId { get; set; }
    public StudentScienceStatus Status { get; set; }
}
