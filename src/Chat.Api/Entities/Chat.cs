namespace Chat.Api.Entities;

public class Chat
{
    public int Id { get; set; }
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    public EChatType ChatType { get; set; }
    public List<Message>? Messages { get; set; }
}
