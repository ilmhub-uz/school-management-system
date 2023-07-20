using Identity.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Api.Extensions;

public static class AddJwtExtension
{
    public static void AddJwtValidation(this IServiceCollection services, IConfiguration configuration)
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

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = async context =>
                    {
                        if (string.IsNullOrEmpty(context.Token))
                        {
                            var accesToken = context.Request.Query["token"];
                            context.Token = accesToken;

                            /* var acesToken = context.Request.Query["token"];
                               var path = context.HttpContext.Request.Path;
                               if(!string.IsNullOrEmpty(accesToken)
                                                   &&path.StartsWithSegments("/hubs"))
                               {
                                   context.Token = accesToken;
                               }*/
                        }
                    }
                };
            });
    }
}