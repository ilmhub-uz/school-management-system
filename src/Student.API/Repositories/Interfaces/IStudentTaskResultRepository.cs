using Student.API.Entities;

namespace Student.API.Repositories.Interfaces;

public interface IStudentTaskResultRepository
{

    Task<List<StudentTaskResult>> GetTaskResultsAsync();
    Task AddTaskResultAsync(StudentTaskResult result);
    Task<StudentTaskResult> GetTaskResultAsync(Guid taskId, Guid studentId);
    Task UpdateTaskResultAsync(StudentTaskResult result);
    Task DeleteTaskResultAsync(StudentTaskResult result);

}
//GET students/{username}/ task - results
//POST students/{username}/ task - results
//GET students/{username}/ task - results /{ task_id}
//PUT students/{username}/ task - results /{ task_id}
//DELETE students/{username}/ task - results /{ task_id}

