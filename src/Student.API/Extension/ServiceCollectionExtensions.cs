﻿namespace Student.API.Extension;

public static class ServiceCollectionExtensions
{
    public static void AddStudentServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddStudentDbContext(configuration);
    }
}