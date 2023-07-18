using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SciencesDbContext>(options =>
{
    options.UseSnakeCaseNamingConvention()
        .UseNpgsql(builder.Configuration.GetConnectionString("SciencesDb"));
});

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
