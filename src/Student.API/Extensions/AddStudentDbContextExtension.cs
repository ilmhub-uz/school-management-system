using Microsoft.EntityFrameworkCore;
using Student.API.Context;

namespace Student.API.Extensions;

public static class AddStudentDbContextExtension
{
    public static void AddStudentDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<StudentDbContext>(config =>
        {
            config.UseNpgsql(configuration.GetConnectionString("StudentDb"));
        });
    }
}