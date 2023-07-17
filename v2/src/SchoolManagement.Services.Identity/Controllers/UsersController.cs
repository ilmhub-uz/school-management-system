using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Identity.Managers;

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
}