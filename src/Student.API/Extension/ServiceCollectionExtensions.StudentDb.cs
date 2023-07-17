using Microsoft.EntityFrameworkCore;
using Student.API.Context;

namespace Student.API.Extension;

public static partial class ServiceCollectionExtensions
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