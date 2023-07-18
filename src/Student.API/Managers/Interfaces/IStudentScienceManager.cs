using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.FluentValidators;
using Student.API.Models.StudentScienceModels;

namespace Student.API.Managers.Interfaces;

public interface IStudentScienceManager
{

    Task<List<StudentScienceModel>> GetStudentSciencesAsync();
    Task<StudentScienceModel> AddStudentScienceAsync(Guid studentId);
    Task<StudentScienceModel> GetStudentScienceByScienceIdAsync(Guid studentId, Guid scienceId);
    Task UpdateStudentScienceAsync(Guid studentId, Guid scienceId, UpdateStudentScienceModel model);
    

}
