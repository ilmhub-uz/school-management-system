using Identity.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("identity_users");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.UserName)
                .IsRequired();

            entity.HasIndex(e => e.UserName)
                .IsUnique();

            entity.Property(e => e.UserName)
                .IsRequired();
        });

    }
}