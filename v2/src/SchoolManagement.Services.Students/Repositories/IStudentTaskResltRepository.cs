using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IStudentTaskResultRepository
{
    ValueTask<IEnumerable<StudentTaskResult>> GetTaskResultsAsync(Guid studentId);
    ValueTask<StudentTaskResult?> GetTaskResultByTaskIdAsync(Guid studentId, Guid taskId);
    ValueTask<StudentTaskResult> CreateTaskResultAsync(StudentTaskResult studentTaskResult);
    ValueTask UpdateTaskResultAsync(StudentTaskResult studentTaskResult);
    ValueTask DeleteTaskResultAsync(StudentTaskResult studentTaskResult);
}
