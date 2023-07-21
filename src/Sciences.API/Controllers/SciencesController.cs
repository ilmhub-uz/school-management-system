using Microsoft.AspNetCore.Mvc;
using Sciences.API.Managers;
using Sciences.API.Models.ScienceModels;

namespace Sciences.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SciencesController : ControllerBase
{
    private readonly ScienceManager _scienceManager;
    // BU shunchaki birinchi versiya xato va kamchiliklari keyingi versiyada jamoamiz bilan to'grilanadi

    public SciencesController(ScienceManager scienceManager)
    {
        _scienceManager = scienceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetSciences()
    {
        var sciences = await _scienceManager.GetSciencesAsync();
        return Ok(sciences);
    }

    [HttpPost]
    public async Task<IActionResult> AddScience(CreateScienceModel model)
    {
        var science = await _scienceManager.AddScienceAsync(model);
        return Ok(science);
    }

    [HttpGet("{scienceId}")]
    public async Task<IActionResult> GetScienceById(Guid scienceId)
    {
        var science = await _scienceManager.GetScienceByIdAsync(scienceId);
        return Ok(science);
    }


    [HttpPut("{scienceId}")]
    public async Task<IActionResult> UpdateScience(Guid scienceId, UpdateScienceModel model)
    {
        var science = await _scienceManager.UpdateScienceAsync(scienceId, model);
        return Ok(science);
    }

    [HttpDelete("{scienceId}")]
    public async Task<IActionResult> DeleteScience(Guid scienceId)
    {
        await _scienceManager.DeleteScienceAsync(scienceId);
        return Ok();
    }

}

