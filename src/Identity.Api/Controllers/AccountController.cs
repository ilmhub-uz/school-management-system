using System.Security.Claims;
using FluentValidation;
using Identity.Api.Context;
using Identity.Api.Models;
using Identity.Api.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private ILogger<AccountController> _logger;
    private readonly TokenService _tokenService;

    public AccountController(
        AppDbContext dbContext, 
        ILogger<AccountController> logger,
        TokenService tokenService)
    {
        _dbContext = dbContext;
        _logger = logger;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> SignUp([FromBody] CreateUserModel createUserModel,
        [FromServices] IValidator<CreateUserModel> userModelValidator)
    {
        var result = await userModelValidator.ValidateAsync(createUserModel);

        if (result.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _dbContext.Users.AnyAsync(u => u.UserName == createUserModel.UserName))
        {
            return BadRequest();
        }

        var user = createUserModel.Adapt<User>();

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserModel loginUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == loginUserModel.UserName);

        if (user == null || user.Password != loginUserModel.Password)
        {
            return NotFound();
        }

        var token = _tokenService.GenerateToken(user);

        return Ok(token);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        return Ok(user);
    }
}