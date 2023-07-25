using SchoolManagement.Services.Students.Models.StudentTaskResultModels;

namespace SchoolManagement.Services.Students.Managers;

public interface IStudentTaskResultManager
{
    public ValueTask<IEnumerable<StudentTaskResultModel>> GetStudentTaskResults(Guid stuentId);
    public ValueTask<StudentTaskResultModel?> GetStudentTaskResult(Guid studentId, Guid taskId);
    public ValueTask<StudentTaskResultModel> CreateStudentTaskResult(Guid studentId, CreateStudentTaskResultModel model);
    public ValueTask UpdateStudentTaskResult(Guid studentId, Guid taskId, UpdateStudentTaskResultModel model);
    public ValueTask DeleteStudentTaskResult(Guid studentId, Guid taskId);
}