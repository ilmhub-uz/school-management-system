using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagement.Services.Sciences.Entities;

namespace SchoolManagement.Services.Sciences.Context;

public class SciencesDbContext : DbContext
{
    public SciencesDbContext(DbContextOptions<SciencesDbContext> options) : base(options)
    {

    }

    public DbSet<Science> Sciences => Set<Science>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<TopicTask> TopicTasks => Set<TopicTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Science>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(e => e.Topics)
                .WithOne(e => e.Science)
                .HasForeignKey(e => e.ScienceId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasIndex(e => e.Name)
                .IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50);

            entity.Property(e => e.Title)
                .HasMaxLength(60);

            entity.Property(e => e.Description)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(e => e.Tasks)
                .WithOne(e => e.Topic)
                .HasForeignKey(e => e.TopicId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasIndex(e => e.Name)
                .IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50);

            entity.Property(e => e.Title)
                .HasMaxLength(60);

            entity.Property(e => e.Description)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<TopicTask>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .HasMaxLength(60);

            entity.Property(e => e.Description)
                .HasMaxLength(255);

            entity.HasOne(e => e.Topic)
                .WithMany(e => e.Tasks)
                .HasForeignKey(e => e.TopicId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestampsForAuditableEntities();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestampsForAuditableEntities()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not IAuditable entity) continue;
            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
    }
}