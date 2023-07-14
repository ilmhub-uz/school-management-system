using Microsoft.AspNetCore.Mvc;

namespace Student.API.Controllers;

[Route("api/students/{username}/attendances")]
[ApiController]
public class StudentAttendanceController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAttendances(string username)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddAttendance(string username)
    {
        return Ok();
    }

    [HttpPut("{attendanceId}")]
    public async Task<IActionResult> UpdateAttendance(string username, Guid attendanceId)
    {
        return Ok();
    }
}