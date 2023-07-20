using Chat.Api.Models.MessageModels;

namespace Chat.Api.Models.ChatModels;

public class ChatModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<MessageModel>? Messages { get; set; }
}
