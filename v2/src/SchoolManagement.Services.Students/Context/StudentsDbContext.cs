using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Context;

public class StudentsDbContext : DbContext
{
    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
    {

    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentAttendance> StudentAttendances => Set<StudentAttendance>();
    public DbSet<StudentScience> StudentSciences => Set<StudentScience>();
    public DbSet<StudentTaskResult> StudentTaskResults => Set<StudentTaskResult>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTaskResult>(entity =>
        {
            entity.HasKey(e => new { e.TaskId, e.StudentId });

            entity.Property(e => e.Content).IsRequired();

            entity.HasOne(e => e.Student)
                .WithMany(s => s.TasksResults)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<StudentScience>(entity =>
        {
            entity.HasKey(e => new { e.ScienceId, e.StudentId });

            entity.HasOne(e => e.Student)
                .WithMany(s => s.Sciences)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => new { e.TopicId, e.StudentId });
            entity.Property(e => e.Attend).IsRequired();
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.PhoneNumber).IsRequired();
            entity.Property(e => e.Username).IsRequired();
            entity.HasIndex(e => e.Username).IsUnique();

            entity.HasMany(e => e.Sciences)
                .WithOne(s => s.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.TasksResults)
                .WithOne(t => t.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Attendances)
                .WithOne()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestampsForAuditableEntities();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestampsForAuditableEntities()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not IAuditable entity) continue;
            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
    }
}