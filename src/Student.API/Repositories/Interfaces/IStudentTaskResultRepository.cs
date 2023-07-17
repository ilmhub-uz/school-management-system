using Microsoft.Extensions.Hosting;
using Student.API.Entities;
using System.Threading.Tasks;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentTaskResultRepository
    {
        Task<List<StudentTaskResult>> GetTaskResultsAsync();
        Task AddTaskResultAsync(StudentTaskResult result);
        Task<StudentTaskResult> GetTaskResultByTaskIdAsync(Guid TaskId);
        Task UpdateTaskResultByTaskIdAsync(Guid TaskId);
        Task DeleteTaskResultByTaskIdAsync(Guid TaskId);

    }
     //GET students/{username}/ task - results
     //POST students/{username}/ task - results
     //GET students/{username}/ task - results /{ task_id}
     //PUT students/{username}/ task - results /{ task_id}
     //DELETE students/{username}/ task - results /{ task_id}
}
