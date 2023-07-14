using Microsoft.AspNetCore.Mvc;
using Student.API.Context;

namespace Student.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly StudentDbContext _dbContext;

    public StudentsController(StudentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _dbContext.Students;

        return Ok(students);
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
