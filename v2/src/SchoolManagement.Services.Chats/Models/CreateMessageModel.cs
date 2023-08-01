using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Models;

public class CreateMessageModel
{
    public required string Content { get; set; }
    public ulong? ParentMessageId { get; set; }
    public string? ChatIdentifier { get; set; }
    public Guid? ToUserId { get; set; }
}
