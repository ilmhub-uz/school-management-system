using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.API.Entities;

namespace Student.API.Context.StudentConfigurations;

public class StudentScienceConfiguration : IEntityTypeConfiguration<StudentScience>
{
    public void Configure(EntityTypeBuilder<StudentScience> builder)
    {
        //This action will change name of table in database in order to use easily in query works.
        builder.ToTable("student_sciences");

        //This action will choose key for the table.
        builder.HasKey(s => s.ScienceId);

        //This action will do these properties like "required".
        builder.Property(s => s.ScienceId).IsRequired(true);
        builder.Property(s => s.StudentId).IsRequired(true);
        builder.Property(s => s.CreatedAt).IsRequired(true);

        //This action will create relation between student and student_science table in database.
        builder.HasOne(s => s.Student)
            .WithMany(s => s.StudentSciences)
            .HasForeignKey(s => s.ScienceId);
    }
}