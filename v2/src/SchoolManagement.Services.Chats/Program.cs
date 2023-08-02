using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Chats.Context;
using SchoolManagement.Services.Chats.Hubs;
using SchoolManagement.Services.Chats.Managers;
using SchoolManagement.Services.Chats.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChatsDbContext>(options =>
{
    options.UseSnakeCaseNamingConvention()
        .UseInMemoryDatabase("ChatsDb");
    //.UseNpgsql(builder.Configuration.GetConnectionString("ChatsDb"));
});

builder.Services.AddMassTransit(c =>
{
    var entryAssembly = Assembly.GetEntryAssembly();
    c.AddConsumers(entryAssembly);

    c.UsingRabbitMq((context, config) =>
    {
        config.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageManager, MessageManager>();
builder.Services.AddScoped<IChatManager, ChatManager>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddSignalR();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.WithHeaders()
    .AllowAnyHeader()
    .AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<ChatHub>("/hubs/chat");

app.MapControllers();

app.Run();
