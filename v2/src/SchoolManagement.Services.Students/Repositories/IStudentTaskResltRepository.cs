using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IStudentTaskResltRepository
{
    ValueTask<IEnumerable<StudentTaskResult>> GetTaskResultsAsync();
    ValueTask<StudentTaskResult> GetTaskResultByTaskIdAsync(Guid taskId);
    ValueTask<StudentTaskResult> CreateTaskResultAsync(StudentTaskResult studentTaskResult);
    ValueTask<StudentTaskResult> UpdateTaskResultAsync(StudentTaskResult studentTaskResult);
    ValueTask DeleteTaskResultAsync(StudentTaskResult studentTaskResult);
}
