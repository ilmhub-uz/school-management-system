using Chat.Api.Extensions;
using Serilog.Events;
using Serilog;
using MassTransit;
using Chat.Api.Managers;
using Chat.Api.Managers.Interfaces;
using Chat.Api.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLog();

builder.Services.AddChatDbContext(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configurations =>
{
    configurations.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });

    configurations.AddConsumer<UserConsumer>();
});

builder.Services.AddChatServices(builder.Configuration);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseChatErrorHandlerMiddleware();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
