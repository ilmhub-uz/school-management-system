using Student.API.Extensions;
using Student.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

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
