using Microsoft.EntityFrameworkCore;
using Student.API.Entities;

namespace Student.API.Context; 

public class StudentDbContext : DbContext
{
    public DbSet<Entities.Student> Students => Set<Entities.Student>();
    public DbSet<StudentAttendance> StudentAttendances => Set<StudentAttendance>();
    public DbSet<StudentScience> StudentSciences => Set<StudentScience>();
    public DbSet<StudentTaskResult> TaskResults => Set<StudentTaskResult>();
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
    
	protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
    }
}
