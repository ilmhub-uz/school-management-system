using Microsoft.AspNetCore.Mvc;
using Sciences.API.Models.ScienceModels;

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
    public async Task<IActionResult> AddScience(CreateScienceModel model)
    {
        return Ok();
    }

    [HttpGet("{scienceId}")]
    public async Task<IActionResult> GetScienceById(Guid scienceId)
    {
        return Ok();
    }

    [HttpPut("{scienceId}")]
    public async Task<IActionResult> UpdateScience(Guid scienceId, UpdateScienceModel model)
    {
        return Ok();
    }

    [HttpDelete("{scienceId}")]
    public async Task<IActionResult> DeleteScience(Guid scienceId)
    {
        return Ok();
    }
}

