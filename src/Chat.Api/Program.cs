using Chat.Api.Extensions;
using Serilog.Events;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddChatServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseChatErrorHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
