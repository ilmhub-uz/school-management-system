using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentsDbContext>(options =>
{
	options.UseSnakeCaseNamingConvention()
		.UseInMemoryDatabase("students");
	//.UseNpgsql(builder.Configuration.GetConnectionString("StudentsDb"));
});

builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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
