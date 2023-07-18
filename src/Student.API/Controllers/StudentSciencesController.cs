using Microsoft.AspNetCore.Mvc;
using Student.API.Entities;
using Student.API.Managers.Interfaces;

namespace Student.API.Controllers;

[Route("api/students/{username}/sciences")]
[ApiController]
public class StudentSciencesController : ControllerBase
{
    private readonly IStudentScienceManager _studentScienceManager;
    private readonly IStudentManager _studentManager;
    public StudentSciencesController(IStudentScienceManager studentScienceManager,IStudentManager studentManager)
    {
        _studentManager = studentManager;
        _studentScienceManager = studentScienceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentSciences()
    {
        var studentSciences = await _studentScienceManager.GetStudentSciencesAsync();
        return Ok(studentSciences);
    }

    [HttpPost("{scienceId}")]
    public async Task<IActionResult> AddStudentScience(string username,Guid scienceId)
    {
        var student = await _studentManager.GetStudentByUserNameAsync(username);
        var studentScience = await _studentScienceManager.AddStudentScienceAsync(student.Id, scienceId);
        return Ok(studentScience);
    }

    [HttpPut("{scienceId}")]
    public async Task<IActionResult> UpdateStudentScience(string username,Guid scienceId,Status? status)
    {
        var student = await _studentManager.GetStudentByUserNameAsync(username);
        await _studentScienceManager.UpdateStudentScienceAsync(student.Id,scienceId,status);

        return Ok();
    }

    [HttpGet("{scienceId}")]
    public async Task<IActionResult> GetStudentScienceByScienceId(string username, Guid scienceId)
    {
        var student = await _studentManager.GetStudentByUserNameAsync(username);
       var studentScience = await _studentScienceManager.GetStudentScienceByScienceIdAsync(student.Id, scienceId);

        return Ok(studentScience);
    }
}
