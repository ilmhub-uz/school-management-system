using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
        var students = await _studentManager.GetStudentsAsync(filterPagination);

        return Ok(students);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromForm] CreateStudentModel model,
        [FromServices] IValidator<CreateStudentModel> validator)
    {
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
            return BadRequest();
        

        await _studentManager.CreateStudentAsync(model);
        return Ok();
    }

    [HttpPut("{studentId}")]
    public async Task<IActionResult> UpdateStudent(Guid studentId, [FromForm] UpdateStudentModel model,
        [FromServices] IValidator<UpdateStudentModel> validator)
    {
        var result = await validator.ValidateAsync(model);
            
        if (!result.IsValid)
            return BadRequest();

        await _studentManager.UpdateStudentAsync(studentId, model);
        return Ok();
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudentById(Guid studentId)
    {
        var student = await _studentManager.GetStudentByIdAsync(studentId);
        return Ok(student);
    }

    [HttpGet("{username}/Username")]
    public async Task<IActionResult> GetStudentByUsername(string username)
    {
        var student = await _studentManager.GetStudentByUserNameAsync(username);
        return Ok(student);
    }

    [HttpDelete("{studentId}")]
    public async Task<IActionResult> DeleteStudent(Guid studentId)
    {
        await _studentManager.DeleteStudentAsync(studentId);
        return Ok();
    }

}
