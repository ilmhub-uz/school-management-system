using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Student.API.Exceptions;
using Student.API.HelperEntities.PaginationEntities;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentModels;

namespace Student.API.Controllers;

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
    public async Task<IActionResult> GetStudents([FromQuery] StudentFilterPagination filterPagination)
    {
        try
        {
            var students = await _studentManager.GetStudentsAsync(filterPagination);
            return Ok(students);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] CreateStudentModel model,
        [FromServices] IValidator<CreateStudentModel> validator)
    {
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
            return BadRequest();

        try
        {
            await _studentManager.CreateStudentAsync(model);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{studentId:guid}")]
    public async Task<IActionResult> UpdateStudent(Guid studentId, [FromForm] UpdateStudentModel model,
        [FromServices] IValidator<UpdateStudentModel> validator)
    {
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
            return BadRequest(result.Errors);

        try
        {
            await _studentManager.UpdateStudentAsync(studentId, model);
            return Ok();
        }
        catch (StudentNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{studentId:guid}", Name = "GetStudentById")]
    public async Task<IActionResult> GetStudentById(Guid studentId)
    {
        try
        {
            var student = await _studentManager.GetStudentByIdAsync(studentId);
            return Ok(student);
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

    [HttpGet("{username:alpha}", Name = "GetStudentByUsername")]
    public async Task<IActionResult> GetStudentByUsername(string username)
    {
        try
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            return Ok(student);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{studentId:guid}", Name = "DeleteStudent")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        try
        {
            await _studentManager.DeleteStudentAsync(studentId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
