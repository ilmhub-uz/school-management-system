using MassTransit;
using SchoolManagement.Core.HelperServices;
using SchoolManagement.Services.Students.Extensions;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(c =>
{
    c.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddStudentDbContext();
builder.Services.AddValidators();
builder.Services.AddRepositories();
builder.Services.AddManagers();
builder.Services.AddProducer();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextHelper>();
builder.Services.AddScoped<FileManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
