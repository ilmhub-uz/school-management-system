using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.API.Entities;

namespace Student.API.Context.StudentConfigurations
{
    public class StudentAttendanceConfiguration : IEntityTypeConfiguration<StudentAttendance>
    {
        public void Configure(EntityTypeBuilder<StudentAttendance> builder)
        {
            builder.ToTable("student_attendance");
            builder.Property(s=> s.StudentId).IsRequired(true);
            builder.Property(s => s.TopicId).IsRequired(true);  
        }
    }
}
