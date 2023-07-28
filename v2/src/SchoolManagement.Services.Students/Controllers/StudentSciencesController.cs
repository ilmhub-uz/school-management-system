using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentScienceModels;

namespace SchoolManagement.Services.Students.Controllers;

[Route("api/students/{studentId}/sciences")]
[ApiController]
public class StudentSciencesController : ControllerBase
{
    private readonly IStudentScienceManager _studentScienceManager;

    public StudentSciencesController(IStudentScienceManager studentScienceManager)
    {
        _studentScienceManager = studentScienceManager;
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddStudentScience(Guid studentId, CreateStudentScienceModel createStudentScience)
    {
        createStudentScience.StudentId = studentId;
        var studentScienceModel = await _studentScienceManager.CreateStudentScienceAsync(createStudentScience);

        return Ok(studentScienceModel);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetStudentSciences(Guid studentId)
    {
        var studentScienceModels = await _studentScienceManager.GetStudentSciencesByStudentIdAsync(studentId);
        if (studentScienceModels == null)
            return NotFound("Object is not found");

        return Ok(studentScienceModels);
    }

    [HttpGet("{scienceId}")]
    public async ValueTask<IActionResult> GetStudentScience(Guid studentId, Guid scienceId)
    {
        var studentScienceModel = await _studentScienceManager.GetStudentScienceAsync(studentId, scienceId);
        if (studentScienceModel == null)
        {
            return NotFound("Object is not found");
        }
        return Ok(studentScienceModel);
    }

   
    [HttpPut("{scienceId}")]
    public async ValueTask<IActionResult> UpdateStudentScience(Guid studentId, Guid scienceId, UpdateStudentScienceModel updateStudentScience)
    {
        try
        {
            var model = await _studentScienceManager
                .UpdateStudentScienceAsync(studentId, scienceId, updateStudentScience);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{scienceId}")]
    public async ValueTask<IActionResult> DeleteStudentScience(Guid studentId, Guid scienceId)
    {
        var isDelete = await _studentScienceManager.DeleteStudentScienceAsync(studentId, scienceId);
        if (!isDelete)
            return BadRequest("Delete was not completed");

        return Ok();
    }
}