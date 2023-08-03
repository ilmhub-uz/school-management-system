using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Context;

public class ChatsDbContext : DbContext
{
    public ChatsDbContext(DbContextOptions<ChatsDbContext> options) : base(options)
    { }

    public DbSet<Chat> Chats => Set<Chat>();
    public DbSet<Message> Messages => Set<Message>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}