using Microsoft.Extensions.Hosting;
using Student.API.Entities;
using System.Threading.Tasks;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentTaskResultRepository
    {
        Task<List<StudentTaskResult>> GetTaskResultsAsync(string studenUsername);
        Task AddTaskResultAsync(string studentUsername,StudentTaskResult result);
        Task GetTaskResultByTaskIdAsync(string studentUsername, Guid TaskId);
        Task UpdateTaskResultByTaskIdAsync(string studentUsername, Guid TaskId);
        Task DeleteTaskResultByTaskIdAsync(string studentUsername, Guid TaskId);

    }
     //GET students/{username}/ task - results
     //POST students/{username}/ task - results
     //GET students/{username}/ task - results /{ task_id}
     //PUT students/{username}/ task - results /{ task_id}
     //DELETE students/{username}/ task - results /{ task_id}
}
