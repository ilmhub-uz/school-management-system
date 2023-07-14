using Microsoft.EntityFrameworkCore;
using Student.API.Context;

namespace Student.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddStudentServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<StudentDbContext>(config =>
        {
            config.UseNpgsql(configuration.GetConnectionString("StudentDb"));
        });
    }
}