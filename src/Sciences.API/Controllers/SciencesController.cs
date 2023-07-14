using Microsoft.AspNetCore.Mvc;

namespace Sciences.API.Controllers;

[Route("api/students/{username}/[controller]")]
[ApiController]
public class SciencesController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetSciences()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddScience()
    {
        return Ok();
    }

    [HttpGet("{science_id}")]
    public async Task<IActionResult> GetScienceById(Guid science_id)
    {
        return Ok();
    }

    [HttpPut("{science_id}")]
    public async Task<IActionResult> UpdateScience(Guid science_id)
    {
        return Ok();
    }

    [HttpDelete("{science_id}")]
    public async Task<IActionResult> DeleteScience(Guid science_id)
    {
        return Ok();
    }
}

