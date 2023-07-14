using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sciences.API.Entities;

namespace Sciences.API.Context.Congiguration
{
    public class TopicConfiguration
    {
        public static void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("science");
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50);
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasMaxLength(50);


        }
    }
}
