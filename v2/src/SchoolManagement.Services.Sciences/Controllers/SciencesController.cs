using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Sciences.Commands;
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
	public async ValueTask<IActionResult> GetSciences([FromQuery] GetSciencesQuery filter)
	{
		var sciences = await _mediator.Send<IEnumerable<ScienceModel>>(filter);

		return Ok(sciences);
	}

	[HttpPost]
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

		/*catch (ValidationException e) when(e.Message == "Error")
		{
			return BadRequest(e.Errors);
		}
		catch (Exception e) when (e is ValidationException || e is NullReferenceException)
		{
			return BadRequest(e.Errors);
		}*/
	}
}