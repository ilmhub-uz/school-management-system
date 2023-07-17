using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Student.API.Extension;
using Student.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().WriteTo
    .File("StudentLogFile.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day).CreateLogger();

builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStudentDbContext(builder.Configuration);
builder.Services.AddModelValidators();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStudentErrorHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
