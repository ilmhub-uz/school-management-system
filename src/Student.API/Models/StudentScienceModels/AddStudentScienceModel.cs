using Student.API.Entities;

namespace Student.API.Models.StudentScienceModels
{
    public class AddStudentScienceModel
    {
        public required Guid ScienceId { get; set; }
        public required Guid StudentId { get; set; }
        
    }
}
