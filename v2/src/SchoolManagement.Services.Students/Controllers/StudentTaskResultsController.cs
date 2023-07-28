using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentTaskResultModels;

namespace SchoolManagement.Services.Students.Controllers;

[Route("api/students/{studentId}/task_results")]
[ApiController]
public class StudentTaskResultController : ControllerBase
{
    private readonly IStudentTaskResultManager _studentTaskResultManager;
    private readonly IStudentManager _studentManager;

    public StudentTaskResultController(
        IStudentTaskResultManager studentTaskResultManager,
        IStudentManager studentManager)
    {
        _studentTaskResultManager = studentTaskResultManager;
        _studentManager = studentManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentTaskResults(Guid studentId)
    {
        var studentTaskResults = await _studentTaskResultManager.GetStudentTaskResults(studentId);
        return Ok(studentTaskResults);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudentTaskResult(Guid studentId, CreateStudentTaskResultModel model)
    {
        var student = await _studentManager.GetByIdAsync(studentId);
        var studentTaskResult = await _studentTaskResultManager.CreateStudentTaskResult(student.Id, model);
        return Ok(studentTaskResult);
    }

    [HttpPut("{taskId:guid}")]
    public async Task<IActionResult> UpdateStudentTaskResult(Guid studentId, Guid taskId, UpdateStudentTaskResultModel model)
    {
        var student = await _studentManager.GetByIdAsync(studentId);
        await _studentTaskResultManager.UpdateStudentTaskResult(student.Id, taskId, model);
        return Ok();
    }

    [HttpDelete("{taskId:guid}")]
    public async Task<IActionResult> DeleteStudentTaskResultAsync(Guid studentId, Guid taskId)
    {
        var student = await _studentManager.GetByIdAsync(studentId);
        await _studentTaskResultManager.DeleteStudentTaskResult(student.Id, taskId);
        return Ok();
    }
}