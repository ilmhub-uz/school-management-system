using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sciences.API.Entities;

namespace Sciences.API.Context.Configurations;

public class TopicConfigurations :IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("topics");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.ScienceId)
            .IsRequired();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(t => t.Name)
            .IsUnique();

        builder.Property(t => t.Title)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .IsRequired();
    }
}