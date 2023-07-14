using Microsoft.EntityFrameworkCore;
using Student.API.Entities;

namespace Student.API.Context; 
public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
    {

    }
    public DbSet<Entities.Student> Students { get; set; }
    public DbSet<StudentAttendance> StudentAttendances { get; set; }
}
