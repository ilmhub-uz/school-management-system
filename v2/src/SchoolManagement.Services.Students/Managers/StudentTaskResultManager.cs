using Mapster;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Models.StudentTaskResultModels;
using SchoolManagement.Services.Students.Repositories;

namespace SchoolManagement.Services.Students.Managers;

public class StudentTaskResultManager : IStudentTaskResultManager
{
    private readonly IStudentTaskResultRepository _studentTaskTaskRepos;
    public StudentTaskResultManager(IStudentTaskResultRepository studentTaskResultRepository)
    {
        _studentTaskTaskRepos = studentTaskResultRepository;
    }
    public async ValueTask<StudentTaskResultModel> CreateStudentTaskResult(Guid studentId, CreateStudentTaskResultModel model)
    {
        var studentTaskResult = new StudentTaskResult()
        {
            StudentId = studentId,
            Content = model.Content,
            CreatedAt = DateTime.UtcNow,


        };
        var studentTaskResultModel = studentTaskResult.Adapt<StudentTaskResultModel>();
        return studentTaskResultModel;
    }

    public async ValueTask DeleteStudentTaskResult(Guid studentId, Guid taskId)
    {
        var studentTaskResult = await _studentTaskTaskRepos.GetTaskResultByTaskIdAsync(studentId, taskId);
        if (studentTaskResult == null)
        {
            throw new Exception("Not Found");
        }

    }

    public async ValueTask<StudentTaskResultModel?> GetStudentTaskResult(Guid studentId, Guid taskId)
    {
        var studentTaskResult = await _studentTaskTaskRepos.GetTaskResultByTaskIdAsync(studentId, taskId);
        if (studentTaskResult == null)
        {
            throw new Exception("Not Found");
        }
        var studentTaskResultModel = studentTaskResult.Adapt<StudentTaskResultModel>();
        return studentTaskResultModel;

    }

    public async ValueTask<IEnumerable<StudentTaskResultModel>> GetStudentTaskResults(Guid studentId)
    {
        var studentTaskResults = await _studentTaskTaskRepos.GetTaskResultsAsync(studentId);
        var studentTaskResultsModels = studentTaskResults.Adapt<IEnumerable<StudentTaskResultModel>>();
        return studentTaskResultsModels;
    }

    public async ValueTask UpdateStudentTaskResult(Guid studentId, Guid taskId, UpdateStudentTaskResultModel model)
    {
        var studentTaskResult = await _studentTaskTaskRepos.GetTaskResultByTaskIdAsync(studentId, taskId);
        if (studentTaskResult == null)
        {
            throw new Exception("Not Found");
        }
        studentTaskResult.Content = model.Content;
        studentTaskResult.UpdatedAt = DateTime.UtcNow;
        await _studentTaskTaskRepos.UpdateTaskResultAsync(studentTaskResult);
    }
}


