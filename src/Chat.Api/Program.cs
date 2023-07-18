using Chat.Api.Extensions;
using Serilog.Events;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLog();

builder.Services.AddChatDbContext(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddChatServices(builder.Configuration);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(c =>
{
    c.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
app.UseHttpsRedirection();

app.UseChatErrorHandlerMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
