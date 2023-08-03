using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Students.Exceptions;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentModels;

namespace SchoolManagement.Services.Students.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentManager _studentManager;

    public StudentsController(IStudentManager studentManager)
    {
        _studentManager = studentManager;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetStudents([FromQuery] StudentFilter studentFilter)
    {
        var student = await _studentManager.GetStudentsAsync(studentFilter);
        return Ok(student);
    }

    [HttpGet("{studentId:guid}")]
    public async ValueTask<IActionResult> GetStudentById(Guid studentId)
    {
        try
        {
            return Ok(await _studentManager.GetByIdAsync(studentId));
        }
        catch (StudentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch
        {
            return NoContent();
        }
    }

    

    [HttpPut("{studentId:guid}")]
    public async ValueTask<IActionResult> UpdateStudent(Guid studentId, [FromForm] UpdateStudentModel model)
    {
        try
        {
            await _studentManager.UpdateAsync(studentId, model);
            return Ok();
        }
        catch (StudentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpDelete("{studentId:guid}")]
    public async ValueTask<IActionResult> DeleteStudent(Guid studentId)
    {
        try
        {
            await _studentManager.DeleteAsync(studentId);
            return Ok();
        }
        catch (StudentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpGet("header")]
    public IActionResult GetHeaderValue()
    {
	    return Ok(HttpContext.Request.Headers["Username"]);
    }
}