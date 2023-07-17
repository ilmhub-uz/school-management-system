using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Identity.Managers;

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
}