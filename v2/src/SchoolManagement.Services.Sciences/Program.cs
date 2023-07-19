using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Behaviors;
using SchoolManagement.Services.Sciences.Commands;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SciencesDbContext>(options =>
{
	options.UseSnakeCaseNamingConvention()
		.UseInMemoryDatabase("sciences_db");
		//.UseNpgsql(builder.Configuration.GetConnectionString("SciencesDb"));
});

builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPipelineBehavior<CreateScienceCommand, ScienceModel>, CreateScienceCommandBehavior>();

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
