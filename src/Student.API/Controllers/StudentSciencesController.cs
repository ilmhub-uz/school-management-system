using Microsoft.AspNetCore.Mvc;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.Managers.Interfaces;

namespace Student.API.Controllers;

[Route("api/students/{username}/sciences")]
[ApiController]
public class StudentSciencesController : ControllerBase
{
    private readonly IStudentScienceManager _studentScienceManager;
    private readonly IStudentManager _studentManager;
    public StudentSciencesController(IStudentScienceManager studentScienceManager, IStudentManager studentManager)
    {
        _studentManager = studentManager;
        _studentScienceManager = studentScienceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentSciences()
    {
        try
        {
            return Ok(await _studentScienceManager.GetStudentSciencesAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{scienceId}")]
    public async Task<IActionResult> AddStudentScience(string username, Guid scienceId)
    {
        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            return Ok(await _studentScienceManager.AddStudentScienceAsync(student.Id, scienceId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); ;
        }
    }

    [HttpPut("{scienceId}")]
    public async Task<IActionResult> UpdateStudentScience(string username, Guid scienceId, Status? status)
    {
        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            await _studentScienceManager.UpdateStudentScienceAsync(student.Id, scienceId, status);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); ;
        }
     
    }

    [HttpGet("{scienceId}")]
    public async Task<IActionResult> GetStudentScienceByScienceId(string username, Guid scienceId)
    {
        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            return Ok(await _studentScienceManager.GetStudentScienceByScienceIdAsync(student.Id, scienceId));
        }
        catch (StudentScienceNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); ;
        }
    }
}