using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Models;
using SchoolManagement.Services.Identity.Exceptions;
using SchoolManagement.Services.Identity.Managers;
using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ISignInManager _signInManager;
    private readonly IBus _bus;
    public AccountController(
        ISignInManager signInManager, IBus bus)
    {
        _signInManager = signInManager;
        _bus = bus;
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetUserAsync()
    {
        try
        {
            var user = await _signInManager.GetUserAsync();
            return Ok(user);
        }
        catch (RecordNotFoundException e)
        {
            return BadRequest(new Error(e.Message));
        }
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> RegisterAsync(
        [FromBody] CreateUserModel createUserModel,
        [FromServices] IValidator<CreateUserModel> validator)
    {
        var validationResult = await validator.ValidateAsync(createUserModel);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var user = await _signInManager.RegisterAsync(createUserModel);

            await _bus.Publish(user);

            return Ok(user);
        }
        catch (Exception e) when (e is RecordNotFoundException or UsernameExistsException)
        {
            return BadRequest(new Error(e.Message));
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResultModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> LoginAsync([FromBody] LoginUserModel loginUserModel)
    {
        try
        {
            var tokenResult = await _signInManager.LoginAsync(loginUserModel);
            return Ok(tokenResult);
        }
        catch (LoginValidationException e)
        {
            return BadRequest(new Error(e.Message));
        }
    }
}