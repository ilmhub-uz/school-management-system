using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models;

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
		var student = await _studentManager.GetStudents();
		return Ok(student);
	}

	[HttpPost]
	public async ValueTask<IActionResult> CreateStudent([FromForm] CreateStudentModel model)
	{
		var student = await _studentManager.CreateAsync(model);

		return Ok(student);
	}
}