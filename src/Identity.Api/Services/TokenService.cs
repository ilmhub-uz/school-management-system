using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.Api.Context;
using Identity.Api.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Services;

public class TokenService
{
	private readonly JwtOption _jwtOption;

	public TokenService(IOptions<JwtOption> jwtOption)
	{
		_jwtOption = jwtOption.Value;
	}

	public string GenerateToken(User user)
	{
		var claims = new List<Claim>()
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.UserName)
		};

		var signingKey = System.Text.Encoding.UTF32.GetBytes(_jwtOption.SigningKey);
		var security = new JwtSecurityToken(
			issuer: _jwtOption.ValidIssuer,
			audience: _jwtOption.ValidAudience,
			claims: claims,
			expires: DateTime.Now.AddSeconds(_jwtOption.ExpiresInSeconds),
			signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
		);

		var token = new JwtSecurityTokenHandler().WriteToken(security);

		return token;
	}
}