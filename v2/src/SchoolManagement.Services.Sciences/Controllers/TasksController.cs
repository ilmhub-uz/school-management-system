using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Sciences.Commands;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Models;
using SchoolManagement.Services.Sciences.Queries;

namespace SchoolManagement.Services.Sciences.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskModel>), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetTasks([FromQuery] GetTasksQuery filter)
    {
        var tasks = await _mediator.Send<IEnumerable<TaskModel>>(filter);
        return Ok(tasks);
    }

    [HttpPost]
    [ProducesResponseType(typeof(TaskModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> CreateTask([FromBody] CreateTaskCommand createTaskCommand)
    {
        try
        {
            var task = await _mediator.Send<TaskModel>(createTaskCommand);
            return Ok(task);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpGet("{taskId:guid}")]
    [ProducesResponseType(typeof(TaskModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetTasks(Guid taskId)
    {
        var query = new GetTaskByIdQuery(taskId);
        try
        {
            var task = await _mediator.Send<TaskModel>(query);
            return Ok(task);
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }

    [HttpPut("{taskId:guid}")]
    public async ValueTask<IActionResult> UpdateTask(Guid taskId, [FromBody] UpdateTaskCommand updateTaskCommand)
    {
        if (taskId != updateTaskCommand.Id)
        {
            return BadRequest();
        }

        try
        {
            await _mediator.Send(updateTaskCommand);
            return Ok();
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }

    [HttpDelete("{taskId:guid}")]
    public async ValueTask<IActionResult> UpdateTask(Guid taskId)
    {
        var command = new DeleteTaskCommand(taskId);
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