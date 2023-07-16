using Identity.Api.Extensions;
using Identity.Api.MiddleWares;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.File("log.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog(logger);
builder.Services.AddIdentityServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseCors(c => 
    c.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseIdentityErrorHandlerMiddleware();

app.MapControllers();

app.Run();
