using Microsoft.AspNetCore.Mvc;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentAttendanceModels;

namespace Student.API.Controllers;

[Route("api/students/{username}/attendances")]
[ApiController]
public class StudentAttendanceController : ControllerBase
{

    private readonly IStudentAttendanceManager _studentAttendanceManager;
    public StudentAttendanceController(IStudentAttendanceManager studentAttendanceManager)
    {
        _studentAttendanceManager = studentAttendanceManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetStudentAttendances()
    {
        var studentAttendance = await _studentAttendanceManager.GetStudentAttendancesAsync();
        return Ok(studentAttendance);
    }
    [HttpPost("{studenId}/{topicId}")]
    public async Task<IActionResult> AddStudentAttendance(Guid studentId,Guid topicId)
    {
        var studentAttendance = await _studentAttendanceManager.AddStudentAttendanceAsync(studentId,topicId);
        if (studentAttendance == null)
        {
            return BadRequest();
        }
        return Ok(studentAttendance);
    }
    [HttpPut("{studenId}/{topicId}")]
    public async Task<IActionResult> UpdateStudentAttendance(Guid studentId,Guid topicId,UpdateStudentAttendanceModel model)
    {
        await _studentAttendanceManager.UpdateStudentAttendanceAsync(studentId,topicId,model);
        return Ok();
    }

}