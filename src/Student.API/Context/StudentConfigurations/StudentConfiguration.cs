using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.API.Entities;

namespace Student.API.Context.StudentConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{

    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.UserName).IsRequired(true);
        builder.Property(s => s.PhoneNumber).IsRequired(true);
        builder.Property(s => s.CreateAt).IsRequired(true);
        builder.Property(s => s.Status).IsRequired(true);
    }
}
