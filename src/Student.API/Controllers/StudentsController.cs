using Microsoft.AspNetCore.Mvc;

namespace Student.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent()
    {
        return Ok();
    }

    [HttpPut("{username}")]
    public async Task<IActionResult> UpdateStudent(string username)
    {
        return Ok();
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetStudentByUsername(string username)
    {
        return Ok();
    }

    [HttpDelete("{username}")]
    public async Task<IActionResult> DeleteStudent(string username)
    {
        return Ok();
    }

}
