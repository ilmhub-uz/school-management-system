using SchoolManagement.Core.Entities;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Models;

public class MessageModel:Entity<ulong>, IAuditable
{
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ulong? ParentMessageId { get; set; }
    public virtual MessageModel? ParentMessage { get; set; }
    public virtual ICollection<Message>? Replies { get; set; }
    public int ChatId { get; set; }
    public virtual ChatModel? Chat { get; set; }
    public Guid UserId { get; set; }
    public virtual UserModel? User { get; set; }
}
