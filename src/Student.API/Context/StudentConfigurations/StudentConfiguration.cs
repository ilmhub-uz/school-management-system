using Microsoft.EntityFrameworkCore;
using Student.API.Entities;

namespace Student.API.Context.StudentConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Student> builder)
    {
        throw new NotImplementedException();
    }
}
