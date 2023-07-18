using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Chats.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChatsDbContext>(options =>
{
    options.UseSnakeCaseNamingConvention()
        .UseNpgsql(builder.Configuration.GetConnectionString("ChatsDb"));
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
