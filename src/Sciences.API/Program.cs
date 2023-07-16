using Sciences.API.Extension;
using Sciences.API.MiddleWares;
using Sciences.API.Repositories;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().WriteTo
    .File("ScienceLoggerFile.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog(logger);
builder.Services.AddScienceServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseScienceErrorHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
