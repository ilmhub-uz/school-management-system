using Microsoft.AspNetCore.Mvc;
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
	public async ValueTask<IActionResult> GetStudents()
	{
		var student = await _studentManager.GetStudentsAsync();
		return Ok(student);
	}

    [HttpGet("{studentId:guid}")]
    public async ValueTask<IActionResult> GetStudentById(Guid studentId)
    {
        var student = await _studentManager.GetByIdAsync(studentId);
        return Ok(student);
    }

    [HttpPost]
	public async ValueTask<IActionResult> CreateStudent([FromForm] CreateStudentModel model)
	{
		var student = await _studentManager.CreateAsync(model);

		return Ok(student);
	}

    [HttpPut("{studentId:guid}")]
    public async ValueTask<IActionResult> UpdateStudent(Guid studentId, [FromForm] UpdateStudentModel model)
    {
        await _studentManager.UpdateAsync(studentId, model);
        return Ok();
    }

	[HttpDelete("{studentId:guid}")]
    public async ValueTask<IActionResult> DeleteStudent(Guid studentId)
    {
        await _studentManager.DeleteAsync(studentId);
        return Ok();
    }
}