using Student.API.Context;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.FluentValidators;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentTaskResults;
using Student.API.Repositories.Interfaces;

namespace Student.API.Managers;

public class StudentTaskResultManager:IStudentTaskResultManager
    
{
    private readonly IStudentTaskResultRepository _studentTaskResultRepos;
    public StudentTaskResultManager(IStudentTaskResultRepository studentTaskResultRepository)
    {
        _studentTaskResultRepos = studentTaskResultRepository;
    }

    public async Task<List<StudentTaskResultModel>> GetStudentTaskResultsAsync()
    {
        var studentTasks = await _studentTaskResultRepos.GetTaskResultsAsync();
        return ToStudentTaskResultModels(studentTasks);
    }
    public async Task<StudentTaskResultModel> GetStudentTaskResultAsync(Guid taskId,Guid studentId)
    {
        var studentTask = await _studentTaskResultRepos.GetTaskResultAsync(taskId,studentId);

        return ToStudentTaskResultModel(studentTask);
    }

    public async Task<StudentTaskResultModel> AddStudentTaskResultAsync(Guid studentId,Guid taskId,string content)
    {
        
        var studentTask = new StudentTaskResult()
        {
            StudentId = studentId,
            TaskId = taskId,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
        };
        await _studentTaskResultRepos.AddTaskResultAsync(studentTask);
        return ToStudentTaskResultModel(studentTask);
    }

    public async Task UpdateStudentTaskResultAsync(Guid studentId,Guid taskId,string content)
    {

        var studentTask = await _studentTaskResultRepos.GetTaskResultAsync(taskId,studentId);
        studentTask.Content = content;
        studentTask.UpdatedAt = DateTime.UtcNow;
        await _studentTaskResultRepos.UpdateTaskResultAsync(studentTask);
        

    }

    public async Task DeleteStudentTaskResultAsync(Guid studentId,Guid taskId)
    {
        var studentTask = await _studentTaskResultRepos.GetTaskResultAsync(taskId,studentId);

        await _studentTaskResultRepos.DeleteTaskResultAsync(studentTask);

    }

    private StudentTaskResultModel ToStudentTaskResultModel(StudentTaskResult studentTaskResult)
    {
        var model = new StudentTaskResultModel()
        {
            StudentId = studentTaskResult.StudentId,
            TaskId = studentTaskResult.TaskId,
            Content = studentTaskResult.Content,
            CreatedAt = studentTaskResult.CreatedAt,
            UpdatedAt= studentTaskResult.UpdatedAt,
        };
        return model;     
    }

    private List<StudentTaskResultModel> ToStudentTaskResultModels(List<StudentTaskResult> studentTasks) 
    {
        if(studentTasks == null || studentTasks.Count == 0)
        {
            return new List<StudentTaskResultModel>();
        }
        var models = new List<StudentTaskResultModel>();
        foreach(var studentTaskResult in studentTasks)
        {
            models.Add(ToStudentTaskResultModel((StudentTaskResult)studentTaskResult));
        }
        return models;
    }


}
