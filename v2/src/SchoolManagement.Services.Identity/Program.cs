using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Identity.Context;
using SchoolManagement.Services.Identity.Extensions;
using SchoolManagement.Services.Identity.Helpers;
using SchoolManagement.Services.Identity.Managers;
using SchoolManagement.Services.Identity.Middlewares;
using SchoolManagement.Services.Identity.Models;
using SchoolManagement.Services.Identity.Producers;
using SchoolManagement.Services.Identity.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenJwt();

builder.Services.AddDbContext<IdentityDbContext>(options =>
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    options.UseSnakeCaseNamingConvention()
	    //.UseNpgsql(builder.Configuration.GetConnectionString("IdentityDb"));
	    .UseInMemoryDatabase("IdentityDb");
});

builder.Services.AddMassTransit(c =>
{
    c.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IUserProducer, UserProducer>();
builder.Services.AddScoped<ISignInManager, SignInManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<ITokenManager, JwtBearerTokenManager>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MigrateIdentityDb();

app.UseHttpsRedirection();

app.UseAuthentication();

HttpContextHelper.Configure(app.Services.GetService<IHttpContextAccessor>());

app.UseAuthorization();

app.UseErrorHandlerMiddleware();

app.MapControllers();

app.Run();

public partial class Program { }