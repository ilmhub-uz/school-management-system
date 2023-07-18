using Microsoft.AspNetCore.Mvc;
using Student.API.Exceptions;
using Student.API.FluentValidators;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentAttendanceModels;

namespace Student.API.Controllers;

[Route("api/students/{username}/attendances")]
[ApiController]
public class StudentAttendancesController : ControllerBase
{
    private readonly IStudentAttendanceManager _studentAttendanceManager;
    private readonly IStudentManager _studentManager;

    public StudentAttendancesController(IStudentAttendanceManager studentAttendanceManager,
        IStudentManager studentManager)
    {
        _studentAttendanceManager = studentAttendanceManager;
        _studentManager = studentManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentAttendances()
    {
        var studentAttendance = await _studentAttendanceManager.GetStudentAttendancesAsync();
        return Ok(studentAttendance);
    }

    [HttpPost("{topicId}")]
    public async Task<IActionResult> AddStudentAttendance(string username, Guid topicId)
    {
        var student = await _studentManager.GetStudentByUserNameAsync(username);

        var studentAttendance = await _studentAttendanceManager.AddStudentAttendanceAsync(student.Id, topicId);

        return Ok(studentAttendance);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudentAttendance(string username,
        [FromForm] UpdateStudentAttendanceModel model)
    {
        var validator = new UpdateStudentAttendanceValidator();
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            throw new UpdateStudentAttendanceValidationInValid("Invalid update input try again");
        }

        var student = await _studentManager.GetStudentByUserNameAsync(username);

        var studentAttendance = await _studentAttendanceManager.UpdateStudentAttendanceAsync(student.Id, model);
        return Ok(studentAttendance);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStudentAttendance(string username, Guid topicId)
    {
        var student = await _studentManager.GetStudentByUserNameAsync(username);
        await _studentAttendanceManager.DeleteStudentAttendancesAsync(student.Id, topicId);

        return Ok();
    }
}
