using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.FluentValidators;
using Student.API.Models.StudentTaskResults;

namespace Student.API.Managers.Interfaces;

public interface IStudentTaskResultManager
{
    Task<List<StudentTaskResultModel>> GetStudentTaskResultsAsync();


    Task<StudentTaskResultModel> AddStudentTaskResultAsync(Guid studentId, AddStudentTaskResultModel model);


    Task UpdateStudentTaskResultAsync(Guid studentId, Guid taskId, UpdateStudentTaskResultModel model);


    Task DeleteStudentTaskResultAsync(Guid studentId, Guid taskId);
    

}
