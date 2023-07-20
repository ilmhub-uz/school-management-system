using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Identity.Models;
using SchoolManagement.Services.Sciences.Commands;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Models;
using SchoolManagement.Services.Sciences.Queries;

namespace SchoolManagement.Services.Sciences.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SciencesController : ControllerBase
{
	private readonly IMediator _mediator;

	public SciencesController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<ScienceModel>), StatusCodes.Status200OK)]
	public async ValueTask<IActionResult> GetSciences([FromQuery] GetSciencesQuery filter)
	{
		var sciences = await _mediator.Send<IEnumerable<ScienceModel>>(filter);
		return Ok(sciences);
	}

	[HttpPost]
    [ProducesResponseType(typeof(ScienceModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> CreateScience([FromBody] CreateScienceCommand createScienceCommand)
	{
		try
		{
			var science = await _mediator.Send<ScienceModel>(createScienceCommand);
			return Ok(science);
		}
		catch (ValidationException e)
		{
			return BadRequest(e.Errors);
		}
	}

    [HttpGet("{scienceId:guid}")]
    [ProducesResponseType(typeof(ScienceModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetScience(Guid scienceId)
    {
        var query = new GetScienceByIdQuery(scienceId);
        try
        {
            var science = await _mediator.Send<ScienceModel>(query);
            return Ok(science);
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }

    [HttpPut("{scienceId:guid}")]
    public async ValueTask<IActionResult> UpdateScience(Guid scienceId, [FromBody] UpdateScienceCommand updateScienceCommand)
    {
        updateScienceCommand.Id = scienceId;
        
        try
        {
            await _mediator.Send(updateScienceCommand);
            return Ok();
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }

    [HttpDelete("{scienceId:guid}")]
    public async ValueTask<IActionResult> DeleteScience(Guid scienceId)
    {
        var command = new DeleteScienceCommand(scienceId);
        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }
}