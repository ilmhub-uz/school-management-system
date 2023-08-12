﻿using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;

namespace SchoolManagement.Services.Students.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static void AddStudentDbContext(this IServiceCollection services,IConfiguration configuration)
    { 
       // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<StudentsDbContext>(options =>
        {
            options.UseSnakeCaseNamingConvention()
                .UseInMemoryDatabase("students");
            //.UseNpgsql(configuration.GetConnectionString("StudentsDb"));
        });
    }
}