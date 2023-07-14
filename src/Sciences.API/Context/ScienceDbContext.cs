using Microsoft.EntityFrameworkCore;
using Sciences.API.Entities;

namespace Sciences.API.Context;

public class ScienceDbContext:DbContext
{
    public DbSet<Science> Sciences => Set<Science>();
    public DbSet<Topic>Topics => Set<Topic>();
    public DbSet<TopicTask> TopicTasks => Set<TopicTask>();

    public ScienceDbContext(DbContextOptions<ScienceDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Topic>(entity =>
        {
            entity.ToTable("topics");

            entity.HasKey(t => t.Id);
            
            entity.Property(t => t.ScienceId)
                .IsRequired();

            entity.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            entity.HasIndex(t => t.Name)
                .IsUnique();

            entity.Property(t => t.Title)
                .IsRequired();

            entity.Property(t => t.CreatedAt)
                .IsRequired();

        });
    }
}