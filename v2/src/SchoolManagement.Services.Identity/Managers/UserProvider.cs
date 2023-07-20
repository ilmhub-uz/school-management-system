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

    public Guid UserId
    {
        get
        {
            if (_contextAccessor.HttpContext is null)
            {
                throw new InvalidOperationException("HttpContext cannot be null.");
            }

            var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
            {
                throw new InvalidOperationException("Value of claim cannot be null.");
            }

            return Guid.Parse(userId);
        }
    }
	public string? Username => _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
}