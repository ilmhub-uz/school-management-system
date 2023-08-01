using SchoolManagement.Core.Entities;
using SchoolManagement.Services.Chats.Models;

namespace SchoolManagement.Services.Chats.Entities;

public class Chat : Entity<ulong>
{
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    public ChatType ChatType { get; set; }
    public virtual ICollection<Message>? Messages { get; set; }
    public virtual ICollection<UserChat>? UserChats { get; set; }
}