using Chat.Api.Entities;

namespace Chat.Api.Models.MessageModels;

public class MessageModel
{
    public int Id { get; set; }
    public User? User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
