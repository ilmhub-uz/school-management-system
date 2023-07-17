using System.Security.Claims;

namespace SchoolManagement.Services.Identity.Managers;

public interface IUserProvider
{
	public Guid UserId { get; }
	public string? Username { get; }
}

public class UserProvider : IUserProvider
{
	private readonly IHttpContextAccessor _contextAccessor;

	public UserProvider(IHttpContextAccessor contextAccessor)
	{
		_contextAccessor = contextAccessor;
	}

	public Guid UserId => Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
	public string? Username => _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
}