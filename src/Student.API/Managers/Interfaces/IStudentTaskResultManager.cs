using Student.API.Models.StudentTaskResults;

namespace Student.API.Managers.Interfaces;

public interface IStudentTaskResultManager
{
    Task<List<StudentTaskResultModel>> GetStudentTaskResultsAsync();
    Task<StudentTaskResultModel> AddStudentTaskResultAsync(Guid studentId,Guid taskId,string content);
    Task UpdateStudentTaskResultAsync(Guid studentId,Guid taskId,string content);
    Task DeleteStudentTaskResultAsync(Guid studentId, Guid taskId);
}
