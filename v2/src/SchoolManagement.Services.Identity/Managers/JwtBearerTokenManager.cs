﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.Api.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Services.Identity.Entities;

namespace SchoolManagement.Services.Identity.Managers;

public class JwtBearerTokenManager : ITokenManager
{
	private readonly JwtOption _jwtOption;

	public JwtBearerTokenManager(IOptions<JwtOption> jwtOption)
	{
		_jwtOption = jwtOption.Value;
	}

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

		var signingKey = System.Text.Encoding.UTF32.GetBytes(_jwtOption.SigningKey);
		var security = new JwtSecurityToken(
		issuer: _jwtOption.ValidIssuer,
			audience: _jwtOption.ValidAudience,
			claims: claims,
			expires: DateTime.UtcNow.AddSeconds(_jwtOption.ExpiresInSeconds),
			signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
		);

		return new JwtSecurityTokenHandler().WriteToken(security);
	}
}