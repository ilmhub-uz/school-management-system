using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.API.Entities;

namespace Student.API.Context.StudentConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Entities.Student>
{

    public void Configure(EntityTypeBuilder<Entities.Student> builder)
    {
        builder.ToTable("students");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Username).IsRequired(true);
        builder.Property(s => s.PhoneNumber).IsRequired(true);
        builder.Property(s => s.CreatedAt).IsRequired(true);
        
    }
}
