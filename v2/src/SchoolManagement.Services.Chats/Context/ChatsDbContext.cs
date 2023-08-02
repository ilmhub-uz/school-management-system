using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Context;

public class ChatsDbContext : DbContext
{
    public ChatsDbContext(DbContextOptions<ChatsDbContext> options) : base(options)
    { }

    public DbSet<Chat> Chats => Set<Chat>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Message> Messages => Set<Message>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasMany(e => e.UserChats)
                .WithOne(e => e.Chat);
        });
    }
}