using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.API.Entities;

namespace Student.API.Context.StudentConfigurations
{
    public class StudentAttendanceConfiguration : IEntityTypeConfiguration<StudentAttendance>
    {
        public void Configure(EntityTypeBuilder<StudentAttendance> builder)
        {
            builder.ToTable("student_attendances");
            builder.HasKey(s => new {s.StudentId,s.TopicId});
            builder.Property(s => s.StudentId).IsRequired(true);
            builder.Property(s => s.TopicId).IsRequired(true);
       }
    }
}
