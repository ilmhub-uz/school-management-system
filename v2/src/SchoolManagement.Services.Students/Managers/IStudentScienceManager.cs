using SchoolManagement.Services.Students.Models.StudentScienceModels;

namespace SchoolManagement.Services.Students.Managers;

public interface IStudentScienceManager
{
    public Task<StudentScienceModel> CreateStudentScienceAsync(CreateStudentScienceModel createStudentScience);
    public Task<StudentScienceModel?> GetStudentScienceAsync(Guid studentId, Guid scienceId);
    public Task<List<StudentScienceModel>?> GetStudentSciencesByStudentIdAsync(Guid studentId);
    public Task<StudentScienceModel> UpdateStudentScienceAsync(Guid studentId, Guid scienceId, UpdateStudentScienceModel updateStudentScience);
    public Task<bool> DeleteStudentScienceAsync(Guid studentId, Guid scienceId);
}
