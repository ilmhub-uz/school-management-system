namespace Chat.Api.Entities;

public class Chat
{
    public required int Id { get; set; }
    public string? Name { get; set; }    
    public string? Description { get; set; }
    public EChatTypes ChatTypes { get; set; }
    public List<Message> Messages { get; set; } = null!;

}
