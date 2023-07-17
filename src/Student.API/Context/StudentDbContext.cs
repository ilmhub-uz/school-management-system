using Microsoft.EntityFrameworkCore;
using Student.API.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.IO;

namespace Student.API.Context; 
public class StudentDbContext:DbContext
{
    public DbSet<Entities.Student> Students { get; set; }
    public DbSet<StudentAttendance> StudentAttendances { get; set; }
    public DbSet<StudentScience> StudentSciences { get; set; }
    public DbSet<StudentTaskResult> TaskResults { get; set; }
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
    
     protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
    }
    
}
