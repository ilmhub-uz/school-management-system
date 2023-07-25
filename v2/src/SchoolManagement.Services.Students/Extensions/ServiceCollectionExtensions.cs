﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.FluentValidation;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentModels;
using SchoolManagement.Services.Students.Repositories;

namespace SchoolManagement.Services.Students.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateStudentModel>, CreateStudentModelValidation>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentTaskResultRepository, StudentTaskResultRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IStudentManager, StudentManager>();
        services.AddScoped<IStudentTaskResultManager, StudentTaskResultManager>();
    }

    public static void AddStudentDbContext(this IServiceCollection services)
    {
        services.AddDbContext<StudentsDbContext>(options =>
        {
            options.UseSnakeCaseNamingConvention()
                .UseInMemoryDatabase("students");
            //.UseNpgsql(builder.Configuration.GetConnectionString("StudentsDb"));
        });
    }
}