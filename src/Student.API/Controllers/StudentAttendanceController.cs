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
        try
        {
            var studentAttendance = await _studentAttendanceManager.GetStudentAttendancesAsync();
            return Ok(studentAttendance);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{topicId:guid}")]
    public async Task<IActionResult> GetStudentAttendances(string username, Guid topicId)
    {
        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            var studentAttendance = await _studentAttendanceManager.GetStudentAttendanceByIdAsync(student.Id, topicId);
            return Ok(studentAttendance);
        }
        catch (StudentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{topicId}")]
    public async Task<IActionResult> AddStudentAttendance(string username, Guid topicId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            var studentAttendance = await _studentAttendanceManager.AddStudentAttendanceAsync(student.Id, topicId);
            return Ok(studentAttendance);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudentAttendance(string username,
        [FromForm] UpdateStudentAttendanceModel model)
    {
        var validator = new UpdateStudentAttendanceValidator();
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
            return BadRequest(result.Errors);

        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            var studentAttendance = await _studentAttendanceManager.UpdateStudentAttendanceAsync(student.Id, model);
            return Ok(studentAttendance);
        }
        catch (StudentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (StudentAttendanceNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (UpdateStudentAttendanceValidationInValidException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStudentAttendance(string username, Guid topicId)
    {
        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            await _studentAttendanceManager.DeleteStudentAttendancesAsync(student.Id, topicId);
            return Ok();
        }
        catch (StudentAttendanceNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); 
        }
    }
}
