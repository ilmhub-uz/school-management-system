using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Student.API.Context;
using Student.API.Extension;
using Student.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().WriteTo
    .File("StudentLogFile.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day).CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddStudentServices(builder.Configuration);


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
