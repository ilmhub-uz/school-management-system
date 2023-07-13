using Identity.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Extensions;

public static class AddJwtExtension
{
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOption>(configuration.GetSection("JwtBearer"));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var signingKey = System.Text.Encoding.UTF32.GetBytes(configuration["JwtBearer:SigningKey"]!);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["JwtBearer:ValidIssuer"],
                    ValidAudience = configuration["JwtBearer:ValidAudience"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
    }
}