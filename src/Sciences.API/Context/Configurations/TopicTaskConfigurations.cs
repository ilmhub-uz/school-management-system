using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sciences.API.Entities;

namespace Sciences.API.Context.Configurations;

public class TopicTaskConfigurations : IEntityTypeConfiguration<TopicTask>
{
    public void Configure(EntityTypeBuilder<TopicTask> builder)
    {
        builder.ToTable("topic_tasks");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        builder.Property(t => t.CreatedAt).IsRequired();

    }
}