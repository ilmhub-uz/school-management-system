using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Chats.Entities;

public class Message : Entity<ulong>, IAuditable
{
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ulong? ParentMessageId { get; set; }
    public virtual Message? ParentMessage { get; set; }
    public virtual ICollection<Message>? Replies { get; set; }
    public ulong ChatId { get; set; }
    public virtual Chat? Chat { get; set; }
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
}