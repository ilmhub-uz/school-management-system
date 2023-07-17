using System.Security.Claims;
using SchoolManagement.Services.Identity.Entities;

namespace SchoolManagement.Services.Identity.Managers;

public class JwtBearerTokenManager : ITokenManager
{
	public string GenerateToken(User user)
	{
		var claims = new List<Claim>()
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.Username)
		};

		if (user.Roles is not null)
		{
			foreach (var userRole in user.Roles)
			{
				if (userRole.Role is { } role)
				{
					claims.Add(new Claim(ClaimTypes.Role, role.Name));
				}
			}
		}

		return string.Empty;
	}
}