using Chat.Api.Entities;

namespace Chat.Api.Models.ChatModels;

public class CreateChatModel
{
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    public EChatType ChatType { get; set; }
}
