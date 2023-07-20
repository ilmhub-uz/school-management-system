using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Identity.Models;
using SchoolManagement.Services.Sciences.Commands;
using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Models;
using SchoolManagement.Services.Sciences.Queries;

namespace SchoolManagement.Services.Sciences.Controllers;

[Route("api/sciences/{scienceId}/[controller]")]
[ApiController]
public class TopicsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TopicsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TopicModel>), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetTopics(Guid scienceId, [FromQuery] GetTopicsQuery filter)
    {
        filter.ScienceId = scienceId;
        var topics = await _mediator.Send<IEnumerable<TopicModel>>(filter);
        return Ok(topics);
    }

    [HttpPost]
    [ProducesResponseType(typeof(TopicModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> CreateTopic(Guid scienceId, [FromBody] CreateTopicCommand command)
    {
        command.ScienceId = scienceId;
        try
        {
            var topic = await _mediator.Send<TopicModel>(command);
            return Ok(topic);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpGet("{topicId:guid}")]
    [ProducesResponseType(typeof(TopicModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetTopic(Guid scienceId, Guid topicId)
    {
        var query = new GetTopicByIdQuery(topicId)
        {
            ScienceId = scienceId
        };

        try
        {
            var topic = await _mediator.Send<TopicModel>(query);
            return Ok(topic);
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }

    [HttpPut("{topicId:guid}")]
    public async ValueTask<IActionResult> UpdateTopic(Guid scienceId, Guid topicId, [FromBody] UpdateTopicCommand command)
    {
        command.ScienceId = scienceId;
        command.Id = topicId;

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

    [HttpDelete("{topicId:guid}")]
    public async ValueTask<IActionResult> DeleteTopic(Guid scienceId, Guid topicId)
    {
        var command = new DeleteTopicCommand(topicId, scienceId);
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