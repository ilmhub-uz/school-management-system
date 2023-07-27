using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Identity.Exceptions;
using SchoolManagement.Services.Identity.Managers;
using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UsersController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetUsersAsync([FromQuery] UserFilter filter)
    {
        var users = await _userManager.GetUsersAsync(filter);
        return Ok(users);
    }

    [HttpGet("{username:alpha}", Name = "GetUserByUsername")]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetUserAsync(string username)
    {
        try
        {
            var user = await _userManager.GetUserAsync(username);
            return Ok(user);
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }

    [HttpGet("{id:guid}", Name = "GetUserById")]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetUserAsync(Guid id)
    {
        try
        {
            var user = await _userManager.GetUserAsync(id);
            return Ok(user);
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(new Error(e.Message));
        }
    }
}