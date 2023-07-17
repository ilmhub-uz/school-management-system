using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Identity.Context;
using SchoolManagement.Services.Identity.Models;
using SchoolManagement.Services.Identity.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityDbContext>(options =>
{
	options.UseSnakeCaseNamingConvention()
		.UseNpgsql(builder.Configuration.GetConnectionString("identity_db"));
});

builder.Services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
