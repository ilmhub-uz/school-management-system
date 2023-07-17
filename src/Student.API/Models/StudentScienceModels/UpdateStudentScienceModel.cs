using Student.API.Entities;

namespace Student.API.Models.StudentScienceModels
{
    public class UpdateStudentScienceModel
    {
        public required Guid ScienceId { get; set; }
        public required Guid StudentId { get; set; }
        public required DateTime CreateAt { get; set; }
        public Status Status { get; set; }
    }
}
