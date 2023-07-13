using System.Security.Claims;
using Identity.Api.Context;
using Identity.Api.Managers;
using Identity.Api.Models;
using Identity.Api.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountManager _accountManager;
    private ILogger<AccountController> _logger;

    public AccountController(
        AppDbContext dbContext,
        ILogger<AccountController> logger,
        TokenService tokenService, AccountManager accountManager)
    {
        _logger = logger;
        _accountManager = accountManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> SignUp([FromBody] CreateUserModel createUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _accountManager.SignUp(createUserModel);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserModel loginUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        
        var token = await _accountManager.Login(loginUserModel);
        return Ok(new { Token = token });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var user = await _accountManager.Profile();

        return Ok(user);
    }
}