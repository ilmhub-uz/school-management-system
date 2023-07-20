using Student.API.Entities;
using Student.API.Models.StudentScienceModels;

namespace Student.API.Managers.Interfaces;

public interface IStudentScienceManager
{
    Task<List<StudentScienceModel>> GetStudentSciencesAsync();
    Task<StudentScienceModel> AddStudentScienceAsync(Guid studentId, Guid scienceId);
    Task<StudentScienceModel> GetStudentScienceByScienceIdAsync(Guid studentId, Guid scienceId);
    Task UpdateStudentScienceAsync(Guid studentId, Guid scienceId, Status? status);
}
