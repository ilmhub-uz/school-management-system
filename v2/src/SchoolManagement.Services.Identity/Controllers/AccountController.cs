﻿using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Identity.Exceptions;
using SchoolManagement.Services.Identity.Managers;
using SchoolManagement.Services.Identity.Models;

namespace SchoolManagement.Services.Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
	private readonly ISignInManager _signInManager;

	public AccountController(ISignInManager signInManager)
	{
		_signInManager = signInManager;
	}

    [HttpGet]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> GetUserAsync()
    {
        try
        {
            var user = await _signInManager.GetUserAsync();
            return Ok(user);
        }
        catch (NotFoundException e)
        {
            return BadRequest(new Error(e.Message));
        }
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> RegisterAsync([FromBody] CreateUserModel createUserModel)
    {
        try
        {
            var user = await _signInManager.RegisterAsync(createUserModel);
            return Ok(user);
        }
        catch (Exception e) when (e is NotFoundException or UsernameExistsException)
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