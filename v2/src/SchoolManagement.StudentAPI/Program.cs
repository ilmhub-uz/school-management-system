using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SchoolManagement.StudentAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenJwt();

builder.Services.AddJwt(builder.Configuration);

builder.Configuration.AddJsonFile("ocelot.json", false, false);
builder.Configuration.AddJsonFile("swagger_configuration.json", false, false);
builder.Services.AddOcelot(builder.Configuration);

var configuration = builder.Configuration;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerForOcelot(configuration);
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();

app.Run();
