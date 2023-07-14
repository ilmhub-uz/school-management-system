using Sciences.API.Extension;
using Sciences.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

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
