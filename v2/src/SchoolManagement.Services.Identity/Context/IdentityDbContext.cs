using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Identity.Entities;

namespace SchoolManagement.Services.Identity.Context;

public class IdentityDbContext : DbContext
{
	public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
	{

	}
	
	public DbSet<User> Users => Set<User>();
	public DbSet<Role> Roles => Set<Role>();
	public DbSet<UserRole> UserRoles => Set<UserRole>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.Id);

			entity.Property(e => e.Username)
				.HasMaxLength(50);

			entity.HasIndex(e => e.Username)
				.IsUnique();

			entity.HasMany(e => e.Roles)
				.WithOne(e => e.User)
				.HasForeignKey(e => e.UserId)
				.OnDelete(DeleteBehavior.Cascade);

            entity.Navigation(e => e.Roles)
                .AutoInclude();
        });

		modelBuilder.Entity<UserRole>(entity =>
		{
			entity.HasKey(e => new { e.UserId, e.RoleId });

			entity.HasOne(e => e.Role)
				.WithMany()
				.HasForeignKey(e => e.RoleId)
				.OnDelete(DeleteBehavior.NoAction);

			entity.HasOne(e => e.User)
				.WithMany(e => e.Roles)
				.HasForeignKey(e => e.UserId)
				.OnDelete(DeleteBehavior.NoAction);

            entity.Navigation(e => e.Role)
                .AutoInclude();
        });

		modelBuilder.Entity<Role>(entity =>
		{
			entity.HasKey(e => e.Id);

			entity.Property(e => e.Name)
				.HasMaxLength(20);

			entity.HasIndex(e => e.Name)
				.IsUnique();
		});
	}
}