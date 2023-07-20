using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.API.Entities;

namespace Student.API.Context.StudentConfigurations;

public class StudentTaskResultConfiguration : IEntityTypeConfiguration<StudentTaskResult>
{
    public void Configure(EntityTypeBuilder<StudentTaskResult> builder)
    {
        builder.ToTable("student_task_results");
        builder.HasKey(s => new { s.StudentId, s.TaskId });

        builder.Property(s => s.Content).IsRequired(true);
        builder.Property(s => s.CreatedAt).IsRequired(true);
    }
}